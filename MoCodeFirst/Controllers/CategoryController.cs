using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoCodeFirst.Models;
using MoCodeFirst.ViewModels;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace MoCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Post([FromBody] CategoryView category)
        {

            var categoryToAdd = new Categories
            {
                Name = category.Name,
                Status = 0,
                SavedAt = DateTime.UtcNow,
                Savedby = Guid.Parse("06E6C8A6-96E6-40A5-8767-7F4D536A2049")
            };

            var mappedCategory = _mapper.Map<Categories>(categoryToAdd);

            var categoryRepo = new CategoryRepo();

            var createdCategory = categoryRepo.Create(mappedCategory);

            if (createdCategory == null)
            {
                return BadRequest("Failed to create category");
            }

            return Ok(createdCategory);
        }
    }
}