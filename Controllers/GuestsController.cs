using Microsoft.AspNetCore.Mvc;
using WebApi.Project.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private List<GuestModel> guests = new List<GuestModel>()
        {
            new GuestModel() { Id = 1, FirstName="Veselin",LastName = "Valkanov" },
            new GuestModel() { Id = 1, FirstName="Lychezara",LastName = "Karnolska" },
            new GuestModel() { Id = 1, FirstName="Petar",LastName = "Petrov" },
        };

        [HttpGet]
        public IEnumerable<GuestModel> Get()
        {
            return guests;
        }

        // GET api/<GuestsController>/5
        [HttpGet("{id}")]
        public ActionResult<GuestModel> Get(int id)
        {
            var res = guests.FirstOrDefault(x => x.Id == id);
            if(res == null)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost]
        public void Post([FromBody] GuestModel value)
        {
            var res = guests.FirstOrDefault(x => x.Id == value.Id);
            if (res != null)
            {
                guests.Remove(res);
            }
            else
            {
                throw new Exception("the id is not valid");
            }
            guests.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GuestModel value)
        {
            guests.Add(value);  
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var res = guests.FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                guests.Remove(res);
            }
            else
            {
                throw new Exception("the id is not valid");
            }
        }
    }
}
