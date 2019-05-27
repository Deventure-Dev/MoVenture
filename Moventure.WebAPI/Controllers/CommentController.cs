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
    public class CommentController : ControllerBase
    {
        
        private readonly IMapper mMapper;

        public CommentController(IMapper mapper)
        {
            mMapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> Get()
        {
            var commentRepo = new CommentRepo();
            var fetchedComments = commentRepo.GetAll();
            var commentsCount = commentRepo.Count();

            if (fetchedComments == null && commentsCount < 0)
            {
                return BadRequest("Fetching comments failed...!");
            }

            var mappedComments = mMapper.Map<Comment>(fetchedComments);

            return Ok(new {
                Comments = mappedComments,
                Count = commentsCount
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Comment> Get(Guid id)
        {
           
            var commentRepo = new CommentRepo();
            var fetchedComment = commentRepo.GetAll().FirstOrDefault(comment => comment.Id == id);

            if (fetchedComment == null)
            {
                return BadRequest("Fetching comment failed...!");
            }

            var mappedComment = mMapper.Map<Comment>(fetchedComment);

            return Ok(mappedComment);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Comment comment)
        {
            var commentRepo = new CommentRepo();
            var mappedComment = mMapper.Map<Comment>(comment);
            var createdComment = commentRepo.Create(mappedComment);

            if (createdComment == null)
            {
                return BadRequest("Failed to create comment");
            }

            return Ok(createdComment);
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
