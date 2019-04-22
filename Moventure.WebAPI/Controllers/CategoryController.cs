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
    public class CategoryController : ControllerBase
    {
        private static DateTime today = DateTime.Today;
        private List<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Action",
                SavedAt = today,
                SavedBy = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "User2",
                    LastName = "LastNameUser2",
                    Email = "test2@yahoo.com",
                    Password = "parola2parola2",
                    Status = false,
                    SavedAt = today
                },

            },

             new Category
            {
                Id = Guid.NewGuid(),
                Name = "Drama",
                SavedAt = today,
                SavedBy = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "User3",
                    LastName = "LastNameUser3",
                    Email = "test3@yahoo.com",
                    Password = "parola3parola3",
                    Status = false,
                    SavedAt = today
                },

            }
        };
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return Categories;
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
