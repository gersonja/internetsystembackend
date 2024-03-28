
using InternetSystem.Models;
using InternetSystem.DBModels;
using InternetSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using InternetSystem.Bll;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCashController : ControllerBase
    {
        private readonly InternetsysContext _db;
        private readonly UserCashRepository UserCashR;

        //GenericResponse<Cash> Resp = new GenericResponse<Cash>();
        // el controlador recibe el dbcontext
        public UserCashController(InternetsysContext dbinternetsysContext)
        {
            _db = dbinternetsysContext;
            UserCashR = new UserCashRepository(_db);

        }
        [HttpGet]
        public GenericResponse<List<Usercash>> Get()
        {
            var userCashFound = UserCashR.GetUsersCashes();
            return new GenericResponse<List<Usercash>>("User cash founds", 200, userCashFound);
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public GenericResponse<Usercash?> Get(int id)
        {
            var userCashFound = UserCashR.GetUserGestorCash(id);
            if (userCashFound != null)
            {
                return new GenericResponse<Usercash?>("", 200, userCashFound);
            }

            return new GenericResponse<Usercash?>("User cash not found", 404, null);
        }

        // POST api/<User>
        [HttpPost]
        public GenericResponse<Usercash?> Post([FromBody] UserCashModelReq userCash)
        {
            // Esta sección, tiene que validar quien es el usuario que esta realizando la acción
            // lo que tenia pensado es que se reciba un string encriptado, el cual se desencripta y se 
            // obtienen todos los datos del usuario.
            UserCashBll UserCashBll = new UserCashBll(_db);

            var userCashCreated = UserCashBll.CreateUserCash(userCash);//UserCashR.CreatedUserCash(_db, userCash);
            
            if (userCashCreated != null)
            {
                return new GenericResponse<Usercash?>("User cash created succesfully", 200, userCashCreated);
            }

            return new GenericResponse<Usercash?>("An error ocurred when creating the user cash.", 400, null);
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{userId}/{cashId}")]
        public GenericResponse<bool> Delete(int userId, int cashId)
        {
    
            bool? validateDeleted = UserCashR.DeleteUserCash(userId, cashId);
            if (validateDeleted == true)
            {
                return new GenericResponse<bool>("User cash removed sucesfully", 200, true);
            }
            else
            {
                return new GenericResponse<bool>("User cash given ID not found", 404, false);
            }
        }
    }
}
