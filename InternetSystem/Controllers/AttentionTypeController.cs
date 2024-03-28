using InternetSystem.DBModels;
using InternetSystem.Models;
using InternetSystem.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttentionTypeController : ControllerBase
    {
        private readonly AttentionTypeRepository AttTypeR;
        private readonly InternetsysContext _db;
        // GET: api/<AttentionTypeController>
        public AttentionTypeController(InternetsysContext db)
        {
            _db = db;
            AttTypeR = new AttentionTypeRepository(_db);
        }

        [HttpGet]
        public GenericResponse<List<Attentiontype>> Get()
        {
            var attentionsTypeFound = AttTypeR.GetAttentionsType();
            return new GenericResponse<List<Attentiontype>>("Attentions found", 200, attentionsTypeFound);
        }

        // GET api/<AttentionTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttentionTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AttentionTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttentionTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
