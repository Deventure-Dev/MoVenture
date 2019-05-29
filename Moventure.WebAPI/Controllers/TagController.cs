using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Models;
//using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace Moventure.WebAPI.Controllers
{
    public class TagController : ControllerBase
    {
        
        private readonly IMapper mMapper;

        public TagController(IMapper mapper)
        {
            mMapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult GetAll()
        {
            var tagRepo = new TagRepo();
            var fetchedTags = tagRepo.GetAll();
            var tagsCount = tagRepo.Count();

            if (fetchedTags == null && tagsCount < 0)
            {
                return BadRequest("Fetching tags failed...!");
            }

            var mappedTags = mMapper.Map<IList<TagModel>>(fetchedTags);

            return Ok(new
            {
                Tags = mappedTags,
                Count = tagsCount
            });
        }

        // GET api/values/5
        [HttpGet]
        public ActionResult<Tag> GetById([FromQuery] Guid id)
        { 
            var tagRepo = new TagRepo();
            var fetchedTag = tagRepo.GetAll().FirstOrDefault(tag => tag.Id == id);

            if (fetchedTag == null)
            {
                return NotFound("Tag with this id doesn't exist...!");
            }

            var mappedTag = mMapper.Map<TagModel>(fetchedTag);

            return Ok(mappedTag);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] TagModel tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input!");
            }

            var tagToAdd = mMapper.Map<Tag>(tag);
            tagToAdd.Status = (int)EntityStatus.ACTIVE;
            tagToAdd.SavedAt = DateTime.UtcNow;


            var claimsIdentity = User.Identity as ClaimsIdentity;
            //tagToAdd.SavedBy = Guid.Parse("06e6c8a6-96e6-40a5-8767-7f4d536a2049"); // User.Claims[0];
            var tagRepo = new TagRepo();
            var createdTag = tagRepo.Create(tagToAdd);

            if (createdTag == null)
            {
                return BadRequest("Failed to create category");
            }

            return Ok(createdTag);
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
            var tagRepo = new TagRepo();
            var fetchedTag = tagRepo.GetAll().FirstOrDefault(tag => tag.Id == id);

            if (fetchedTag == null)
            {
                return NotFound("Tag with this id doesn't exist...!");
            }

            tagRepo.Delete(fetchedTag);

            return Ok(fetchedTag);
        }
    }
}
