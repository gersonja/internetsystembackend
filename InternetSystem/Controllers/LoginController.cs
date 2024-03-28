using InternetSystem.DBModels;
using InternetSystem.Models;
using InternetSystem.Repository;
using InternetSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly UserRepository UserR;
        private readonly InternetsysContext _db;
        private IConfiguration _config;

        public LoginController(InternetsysContext db, IConfiguration config)
        {
            _db = db;
            UserR = new UserRepository(_db);
            _config = config;
        }

        [HttpPost]
        public dynamic IniciarSesion([FromBody] LoginRequestModel model)
        {
            var user = model.username;
            var password = model.password;

            User userFound = UserR.GetUserByUsernameAndPassword(user, password);

            if(userFound == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    token = ""
                };
            }

            var jwt = _config.GetSection("Jwt").GetValue<string>("key");

            Console.WriteLine("Este debería ser el jwt: "+jwt);

            var claims = new[]
            {
                new Claim("username", userFound.Username),
                new Claim("token", userFound.RolRolid.ToString()),
                new Claim("Iat", DateTime.Now.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt));
            var signingCredent = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredent
             );

            return new
            {
                success = true,
                message = "Credenciales correctas",
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }


        //private readonly IAuthService _authService;
        //public LoginController(IAuthService authService)
        //{
        //    _authService = authService;
        //}
        //// POST api/<LoginController>
        //[HttpPost]
        //public async Task<ActionResult> Login([FromBody] LoginRequestModel model)
        //{
        //    var response = await _authService.ReturnToken(model);
        //    if (response == null)
        //    {
        //        return Unauthorized();
        //    }
        //    if (response.Token == null)
        //    {
        //        return BadRequest(response.Msg);
        //    }
        //    return Ok(response);
        //}

    }
}
