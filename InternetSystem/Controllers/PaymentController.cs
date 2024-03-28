using InternetSystem.DBModels;
using InternetSystem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PaymentController : ControllerBase
    {
        private readonly InternetsysContext _db;
        public PaymentController(InternetsysContext db)
        {
            _db = db;
        }
        // GET api/<PaymentController>/5
        [HttpGet("{id}")]

        public GenericResponse<dynamic> Get(int id)
        {
            var payments = _db.Payments.Where(p => p.Clientid == id).ToList();
            return new GenericResponse<dynamic>("Payments of the client", 200, payments);
        }

        // POST api/<PaymentController>
        [HttpPost]
        public GenericResponse<dynamic> Post([FromBody] PaymentModelReq paymentModel)
        {
            var model = new Payment()
            {
                Amount = paymentModel.Amount,
                Clientid = paymentModel.Clientid,
                Contractid = paymentModel.Contractid,
                Paymentdate = paymentModel.Paymentdate,
            };
            try
            {
                _db.Payments.Add(model);
                _db.SaveChanges();
                return new GenericResponse<dynamic>("Payment registered sucessfully", 200, model);
            } catch (Exception)
            {
                return new GenericResponse<dynamic>("An error ocurred registering payment", 500, model);
            }
        }
    }
}
