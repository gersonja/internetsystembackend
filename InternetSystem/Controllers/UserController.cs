using Microsoft.AspNetCore.Mvc;
using InternetSystem.Repository;
using InternetSystem.DBModels;
using InternetSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository UserR;
        private readonly InternetsysContext _db;

        public UserController(InternetsysContext db)
        {
            _db = db;
            UserR = new UserRepository(_db);
        }

        // GET: api/<User>
        [HttpGet]
        public GenericResponse<List<User>> Get()
        {
            var usersFound = UserR.GetUsers();
            return new GenericResponse<List<User>>("Users founds", 200, usersFound);
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public GenericResponse<User?> Get(int id)
        {
            var userFound = UserR.GetUser(id);
            if (userFound != null)
            {
                return new GenericResponse<User?>("", 200, userFound);
            }

            return new GenericResponse<User?>("User not found", 404, null);
        }

        // POST api/<User>
        [HttpPost]
        public GenericResponse<User?> Post([FromBody] UserModelReq user)
        {
            // Esta sección, tiene que validar quien es el usuario que esta realizando la acción
            // lo que tenia pensado es que se reciba un string encriptado, el cual se desencripta y se 
            // obtienen todos los datos del usuario.
            var userCreated = UserR.CreateUser(user);

            if (userCreated != null)
            {
                return new GenericResponse<User?>("User created succesfully", 200, userCreated);
            }
            
            return new GenericResponse<User?>("An error ocurred when creating the user.", 400, null);
        }

        // PUT api/<User>/5
        [HttpPut("{id}")]
        public GenericResponse<User?> Put(int id, [FromBody] UserModelReq UserM)
        {
            // Esta sección, tiene que validar quien es el usuario que esta realizando la acción
            User? userUpdated = UserR.UpdateUser(id, UserM);
            if (userUpdated != null)
            {
                return new GenericResponse<User?>("User updated succesfully", 200, userUpdated);
            }

            return new GenericResponse<User?>("An error ocurred when updating user", 400, userUpdated);
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public GenericResponse<int> Delete(int id)
        {
            // Esta sección, tiene que validar quien es el usuario que esta realizando la acción
            string? message = UserR.DeleteUserById(id);
            if (message != null)
            {
                return new GenericResponse<int>("User removed sucesfully", 200, id);
            } else
            {
                return new GenericResponse<int>("User with given ID not found", 404, id);
            }
        }
    }
}
