using InternetSystem.Bll;
using InternetSystem.DBModels;
using InternetSystem.Filters;
using InternetSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [ServiceFilter(typeof(SessionUserFilter))]   // esta es una prueba... aquí no va ningún interceptor... va sólo en las rutas protegidas.
    public class ClientController : ControllerBase
    {
        private readonly InternetsysContext _db;
        private readonly ClientBll ClientB;

        public ClientController(InternetsysContext db)
        {
            _db = db;
            ClientB = new ClientBll(db);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{identification}")]
        public GenericResponse<Client?> Get(string identification)
        {
            Client client = ClientB.GetClientByIdentification(identification);
            return new GenericResponse<Client?>("Succesfully", 200, client);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public GenericResponse<Client?> Post([FromBody] ClientModelReq model)
        {
            var createdUser = ClientB.AddClient(model);
            if (createdUser != null)
            {
                return new GenericResponse<Client?>("Client created succesfully", 200, createdUser);
            }

            return new GenericResponse<Client?>("A problem ocurred when creating the new client", 500, null);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
