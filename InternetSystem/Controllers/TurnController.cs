using InternetSystem.DBModels;
using InternetSystem.Models;
using InternetSystem.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        // GET: api/<TurnController>
        private readonly InternetsysContext _db;
        private readonly TurnRepository TurnR;
       
        public TurnController(InternetsysContext dbinternetsysContext)
        {
            _db = dbinternetsysContext;
            TurnR = new TurnRepository(_db);
        }
        [HttpGet]
        public GenericResponse<List<Turn>> Get()
        {
            var TurnsFound = TurnR.GetTurns();
            return new GenericResponse<List<Turn>>("Turns founds", 200, TurnsFound);
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public GenericResponse<Turn?> Get(int id)
        {
            var TurnFound = TurnR.GetTurn(id);
            if (TurnFound != null)
            {
                return new GenericResponse<Turn?>("", 200, TurnFound);
            }

            return new GenericResponse<Turn?>("Turn not found", 404, null);
        }

        // POST api/<TurnController>
        [HttpPost]
        public GenericResponse<TurnModelResponse?> Post([FromBody] CreationTurnModelReq model)
        {
            var createdTurn = TurnR.CreateTurn(model);
            if (createdTurn != null)
            {
                return new GenericResponse<TurnModelResponse?>("Created Turn succesfully", 200, createdTurn);
            }

            return new GenericResponse<TurnModelResponse?>("An error ocurred when creating the turn", 200, null);
        }

        // PUT api/<TurnController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TurnController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
