using LibraryManager.web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private static List<Users> Dummy = new List<Users>
        {
            new Users(),
            new Users{ Name = "Abhishek"},
            new Users{Username = "Meow69k" ,Name = "Kritika"}
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Users>> Get() {
            return Ok(Dummy);
        }

        [HttpGet("GetSingle")]
        public ActionResult<Users> Get(String name)
        {
            return Ok(Dummy.FirstOrDefault(c => c.Name.Equals(name)));
        }

      
    }
}
