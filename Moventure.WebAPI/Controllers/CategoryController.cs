using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace Moventure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static DateTime today = DateTime.Today;
        private List<CategoryModel> Categories = new List<CategoryModel>
        {
            new CategoryModel
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

             new CategoryModel
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
        private readonly IMapper mMapper;

        public CategoryController(IMapper mapper)
        {
            mMapper = mapper;
        }
        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<Category>> Get()
        public IActionResult Get()
        {
            var categories = new CategoryRepo().GetAll();
            //IList<CategoryModel>
            Console.WriteLine(mMapper);
               var mappedCategories = mMapper.Map<CategoryModel>(categories);
            return Ok(mappedCategories);
            //return Categories;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //return "value";
            var category = new Categories
            {
                Name = id.ToString(),
                Status = 0,
                SavedAt = DateTime.UtcNow,
                Savedby = Guid.Parse("06E6C8A6-96E6-40A5-8767-7F4D536A2049")
            };

            var categoryRepo = new CategoryRepo();
            var createdCategory = categoryRepo.Create(category);
            if (createdCategory == null)
            {
                return BadRequest("Failed to create category");
            }
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            var category = new Categories
            {
                Name = value,
                Status = 0,
                SavedAt = DateTime.UtcNow,
                Savedby = Guid.Parse("06E6C8A6-96E6-40A5-8767-7F4D536A2049")
            };

            var categoryRepo = new CategoryRepo();
            var createdCategory = categoryRepo.Create(category);
            if (createdCategory == null)
            {
                return BadRequest("Failed to create category");
            }
            return Ok();
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
