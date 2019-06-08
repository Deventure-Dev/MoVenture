using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Models;
//using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace Moventure.WebAPI.Controllers
{
    public class CommentController : ControllerBase
    {
        
        private readonly IMapper mMapper;

        public CommentController(IMapper mapper)
        {
            mMapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            var commentRepo = new CommentRepo();
            var fetchedComments = commentRepo.GetAll();
            var commentsCount = commentRepo.Count();

            if (fetchedComments == null && commentsCount < 0)
            {
                return BadRequest("Fetching comments failed...!");
            }
            
            var mappedComments = mMapper.Map<IList<CommentModel>>(fetchedComments);

            return Ok(new {
                Comments = mappedComments,
                Count = commentsCount
            });
        }

        // GET api/values/5
        [HttpGet]
        public ActionResult<CommentModel> GetById([FromQuery] Guid commentId)
        {
           
            var commentRepo = new CommentRepo();
            var fetchedComment = commentRepo.GetAll().FirstOrDefault(comment => comment.Id == commentId);

            if (fetchedComment == null)
            {
                return BadRequest("Fetching comment failed...!");
            }

            var mappedComment = mMapper.Map<CommentModel>(fetchedComment);

            return Ok(mappedComment);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromQuery] Guid movieId, [FromBody] CommentModel comment)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input!");
            }

            var movieRepo = new MovieRepo();

            var fetchedMovie = movieRepo.Get(movieId);

            if(fetchedMovie == null)
            {
                return BadRequest("Sorry this movie doesn't exist...");
            }

            var commentRepo = new CommentRepo();
            var mappedComment = mMapper.Map<DataLayer.Models.Comment>(comment);
            //mappedComment.SavedAtMovie = fetchedMovie;
            mappedComment.Id = new Guid();
            mappedComment.Status = (int)EntityStatus.ACTIVE;
            mappedComment.SavedAt = DateTime.UtcNow;
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
