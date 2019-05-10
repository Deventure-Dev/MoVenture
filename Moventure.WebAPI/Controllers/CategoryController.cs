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
        
        private readonly IMapper mMapper;

        public CategoryController(IMapper mapper)
        {
            mMapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CategoryModel>> Get()
        {
            var categoryRepo = new CategoryRepo();
            var fetchedCategories = categoryRepo.GetAll();
            var categoriesCount = categoryRepo.Count();

            if (fetchedCategories == null && categoriesCount < 0)
            {
                return BadRequest("Fetching categories failed...!");
            }

            var mappedCategories = mMapper.Map<CategoryModel>(fetchedCategories);

            return Ok(new {
                Categories = mappedCategories,
                Count = categoriesCount
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<CategoryModel> Get(Guid id)
        {
           
            var categoryRepo = new CategoryRepo();
            var fetchedCategory = categoryRepo.GetAll().FirstOrDefault(category => category.Id == id);

            if (fetchedCategory == null)
            {
                return BadRequest("Fetching category failed...!");
            }

            var mappedCategory = mMapper.Map<CategoryModel>(fetchedCategory);

            return Ok(mappedCategory);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(CategoryModel model)
        {
            var categoryToAdd = new Categories
            {
                Name = model.Name,
                Status = 0,
                SavedAt = DateTime.UtcNow,
                Savedby = Guid.Parse("06E6C8A6-96E6-40A5-8767-7F4D536A2049")
            };

            var categoryRepo = new CategoryRepo();
            var createdCategory = categoryRepo.Create(categoryToAdd);

            if (createdCategory == null)
            {
                return BadRequest("Failed to create category");
            }

            return Ok(createdCategory);
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
