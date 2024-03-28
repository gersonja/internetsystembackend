using InternetSystem.DBModels;
using Microsoft.AspNetCore.Mvc;
using InternetSystem.Repository;
using InternetSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttentionController : ControllerBase
    {
        private readonly AttentionRepository AttR;
        private readonly InternetsysContext _db;

        public AttentionController(InternetsysContext db)
        {
            _db = db;
            AttR = new AttentionRepository(_db);
        }

        [HttpGet]
        public GenericResponse<List<Attention>> Get()
        {
            var attentionsFound = AttR.GetAttentions();
            return new GenericResponse<List<Attention>>("Attentions found", 200, attentionsFound);
        }

        [HttpGet("{id}")]
        public GenericResponse<Attention?> Get(int id)
        {
            var attentionFound = AttR.GetAttention(id);
            if (attentionFound != null) 
            {
                return new GenericResponse<Attention?>("", 200, attentionFound);
            }
            return new GenericResponse<Attention?>("Attention nos found", 404,null);
        }

        // POST api/<AttentionController>
        [HttpPost]
        public GenericResponse<Attention?> Post([FromBody] AttentionModelReq attention)
        {
            var createdAttention = AttR.CreateAttention(attention);
            if (createdAttention != null)
            {
                return new GenericResponse<Attention?>("Attention created succesfully", 200, createdAttention);
            }
            return new GenericResponse<Attention?>("A problem ocurred when creating the new attention", 500, null);
        }

        // PUT api/<AttentionController>/5
        [HttpPut("{id}")]
        public GenericResponse<Attention?> Put(int id, [FromBody] AttentionModelReq attentionM)
        {
            var updatedAttention = AttR.UpdateAttention(id, attentionM);
            if (updatedAttention != null)
            {
                return new GenericResponse<Attention?>("Attention updated succesfully", 200, updatedAttention);
            }

            return new GenericResponse<Attention?>("A problem ocurred when updating the new attention", 500, null);
        }

        // DELETE api/<AttentionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
