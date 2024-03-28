using InternetSystem.Models;
using InternetSystem.DBModels;
using InternetSystem.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private readonly InternetsysContext _db;
        private readonly  CashRepository CashR;
        //GenericResponse<Cash> Resp = new GenericResponse<Cash>();
        // el controlador recibe el dbcontext
        public CashController(InternetsysContext dbinternetsysContext)
        {
            _db = dbinternetsysContext;
            CashR = new CashRepository(_db);
        }
        [HttpGet]
        public GenericResponse<List<Cash>> Get()
        {
            var cashesFound = CashR.GetCashes();
            return new GenericResponse<List<Cash>>("Cash founds", 200, cashesFound);
        }

        // GET api/<Cash>/5
        [HttpGet("{id}")]
        public GenericResponse<Cash?> Get(int id)
        {
            var cashFound = CashR.GetCash(id);
            if (cashFound != null)
            {
                return new GenericResponse<Cash?>("", 200, cashFound);
            }

            return new GenericResponse<Cash?>("Cash not found", 404, null);
        }

        // POST api/<Cash>
        [HttpPost]
        public GenericResponse<Cash?> Post( [FromBody] CashModelReq cash)
        {
            // Esta sección, tiene que validar quien es el usuario que esta realizando la acción
            // lo que tenia pensado es que se reciba un string encriptado, el cual se desencripta y se 
            // obtienen todos los datos del usuario.
            var cashCreated = CashR.CreatedCash(_db,cash);

            if (cashCreated != null)
            {
                return new GenericResponse<Cash?>("Cash created succesfully", 200, cashCreated);
            }

            return new GenericResponse<Cash?>("An error ocurred when creating the cash.", 400, null);
        }

        // PUT api/<Cash>/5
        [HttpPut("{id}")]
        public GenericResponse<Cash?> Put(int id, [FromBody] CashModelReq cash)
        {
            // Esta sección, tiene que validar quien es el usuario que esta realizando la acción
            Cash? cashUpdated = CashR.UpdatedCash(_db, cash,id);
            if (cashUpdated != null)
            {
                return new GenericResponse<Cash?>("Cash updated succesfully", 200, cashUpdated);
            }

            return new GenericResponse<Cash?>("An error ocurred when updating cash", 400, cashUpdated);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
