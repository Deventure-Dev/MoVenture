using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Helpers;
using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace Moventure.WebAPI.Controllers
{
    public class CategoryController : ControllerBase
    {

        private readonly IMapper mMapper;

        public CategoryController(IMapper mapper)
        {
            mMapper = mapper;

        }
        // GET api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryRepo = new CategoryRepo(mMapper);
            var fetchedCategories = categoryRepo.GetAll();
            var categoriesCount = categoryRepo.Count();

            if (fetchedCategories == null && categoriesCount < 0)
            {
                return BadRequest("Fetching categories failed...!");
            }

            var mappedCategories = mMapper.Map<IList<CategoryModel>>(fetchedCategories);

            return Ok(new
            {
                Categories = mappedCategories,
                Count = categoriesCount
            });
        }

        // GET api/values/5
        [HttpGet]
        public ActionResult<CategoryModel> GetById([FromQuery] Guid id)
        {

            var categoryRepo = new CategoryRepo(mMapper);
            var fetchedCategory = categoryRepo.GetAll().FirstOrDefault(category => category.Id == id);

            if (fetchedCategory == null)
            {
                return NotFound("Category with this id doesn't exist...!");
            }

            var mappedCategory = mMapper.Map<CategoryModel>(fetchedCategory);

            return Ok(mappedCategory);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input!");
            }

            var categoryToAdd = mMapper.Map<Category>(model);
            categoryToAdd.Status = (int)EntityStatus.ACTIVE;
            categoryToAdd.SavedAt = DateTime.UtcNow;


            var claimsIdentity = User.Identity as ClaimsIdentity;
            categoryToAdd.Savedby = Guid.Parse("06e6c8a6-96e6-40a5-8767-7f4d536a2049"); // User.Claims[0];
            var categoryRepo = new CategoryRepo(mMapper);
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
        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var categoryRepo = new CategoryRepo(mMapper);
            var fetchedCategory = categoryRepo.GetAll().FirstOrDefault(category => category.Id == id);

            if (fetchedCategory == null)
            {
                return NotFound("Category with this id doesn't exist...!");
            }

            categoryRepo.Delete(fetchedCategory);

            return Ok(fetchedCategory);
        }
    }
}
