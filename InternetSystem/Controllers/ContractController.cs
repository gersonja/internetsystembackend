using InternetSystem.DBModels;
using Microsoft.AspNetCore.Mvc;
using InternetSystem.Repository;
using InternetSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ContractRepository ContractR;
        private readonly InternetsysContext _db;

        public ContractController(InternetsysContext db)
        {
            _db = db;
            ContractR = new ContractRepository(_db);
        }

        [HttpGet("client/{id}")]
        public GenericResponse<List<Contract>> GetByClientId(int id)
        {
            var contractsFound = ContractR.GetContractsByClientId(id);
            return new GenericResponse<List<Contract>>("Contracts found", 200, contractsFound);
        }

        [HttpGet("{id}")]
        public GenericResponse<Contract?> Get(int id)
        {
            var contractFound = ContractR.GetContract(id);
            if (contractFound != null) 
            {
                return new GenericResponse<Contract?>("", 200, contractFound);
            }
            return new GenericResponse<Contract?>("Contract nos found", 404,null);
        }

        // POST api/<ContractController>
        [HttpPost]
        public GenericResponse<Contract?> Post([FromBody] ContractModelReq contract)
        {
            var createdContract = ContractR.CreateContract(contract);
            if (createdContract != null)
            {
                return new GenericResponse<Contract?>("Contract created succesfully", 200, createdContract);
            }
            return new GenericResponse<Contract?>("A problem ocurred when creating the new contract", 500, null);
        }

        // PUT api/<ContractController>/5
        [HttpPut("{id}")]
        public GenericResponse<Contract?> Put(int id, [FromBody] ContractModelReq contractM)
        {
            var updatedContract = ContractR.UpdateContract(id, contractM);
            if (updatedContract != null)
            {
                return new GenericResponse<Contract?>("Contract updated succesfully", 200, updatedContract);
            }

            return new GenericResponse<Contract?>("A problem ocurred when updating the new contract", 500, null);
        }

        // DELETE api/<ContractController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
