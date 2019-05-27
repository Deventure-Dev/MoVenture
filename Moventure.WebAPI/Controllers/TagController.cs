using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace Moventure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        
        private readonly IMapper mMapper;

        public TagController(IMapper mapper)
        {
            mMapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Tag>> Get()
        {
            var tagRepo = new TagRepo();
            var fetchedTags = tagRepo.GetAll();
            var tagsCount = tagRepo.Count();

            if (fetchedTags == null && tagsCount < 0)
            {
                return BadRequest("Fetching tags failed...!");
            }

            var mappedTags = mMapper.Map<Tag>(fetchedTags);

            return Ok(new {
                Tags = mappedTags,
                Count = tagsCount
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Tag> Get(Guid id)
        {
           
            var tagRepo = new TagRepo();
            var fetchedTag = tagRepo.GetAll().FirstOrDefault(tag => tag.Id == id);

            if (fetchedTag == null)
            {
                return BadRequest("Fetching tag failed...!");
            }

            var mappedTag = mMapper.Map<Tag>(fetchedTag);

            return Ok(mappedTag);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Tag tag)
        {
            var tagToAdd = new Tag
            {
                Id = new Guid(),
                Name = tag.Name,
                SavedAt = DateTime.UtcNow,
                Status = 0
            };

            var tagRepo = new TagRepo();
            var createdTag = tagRepo.Create(tagToAdd);

            if (createdTag == null)
            {
                return BadRequest("Failed to create tag");
            }

            return Ok(createdTag);
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
