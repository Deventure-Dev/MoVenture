using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Models;

namespace Moventure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static DateTime today = DateTime.Today;
        private List<User> Users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "User1",
                LastName = "LastNameUser1",
                Email = "test@yahoo.com",
                Password = "parolaparola",
                Status = false,
                SavedAt = today
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Mircea",
                LastName = "Popescu",
                Email = "mirceat@yahoo.com",
                Password = "pa122rolaparola",
                Status = false,
                SavedAt = today
            },
        };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
