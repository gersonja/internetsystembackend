using InternetSystem.DBModels;
using InternetSystem.Models;
using InternetSystem.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InternetSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuRepository MenuR;
        private readonly InternetsysContext _db;

        public MenuController(InternetsysContext db)
        {
            _db = db;
            MenuR = new MenuRepository(_db);
        }

        // GET api/<Menu>
        [HttpGet]
        public GenericResponse<List<Menu>> Get()
        {
            var menuFound = MenuR.GetMenus();
            return new GenericResponse<List<Menu>>("Menu founds", 200, menuFound);
        }
        // GET api/<Menu>/5
        [HttpGet("{id}")]
        public GenericResponse<List<Menu>> Get(int id)
        {
            var menuFound = MenuR.GetMenu(id);
            if (menuFound != null)
            {
                return new GenericResponse<List<Menu>>("", 200, menuFound);
            }

            return new GenericResponse<List<Menu>>("Menu not found", 404, null);
        }
        // POST api/<MenuController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
