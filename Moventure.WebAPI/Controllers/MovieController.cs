using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Deventure.Common.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace Moventure.WebAPI.Controllers
{

    public class MovieController : Controller
    {
        private static DateTime today = DateTime.Today;

        private readonly IMapper mMapper;

        public MovieController(IMapper mapper)
        {
            mMapper = mapper;
        }

        public IActionResult Index()
        {
            return View("MovieDetails");
        }

        public IActionResult AddMovie()
        {
            return View("AddMovie");
        }

        #region WEBAPI specific

        // GET api/values/5
        [HttpGet]
        public ActionResult<Movie> GetAll()
        {
            var movieRepo = new MovieRepo();
            var fetchedMovies = movieRepo.GetList(movie => movie.Status == (int)EntityStatus.ACTIVE, new [] 
                                {
                                    $"{nameof(Movie.TagList)}.{nameof(TagsMovieAssignment.Tag)}",
                                    $"{nameof(Movie.ActorList)}.{nameof(MovieActorAssignment.Actor)}",
                                    $"{nameof(Movie.Category)}"
                                });
            var moviesCount = movieRepo.Count();

            if (fetchedMovies == null && moviesCount < 0)
            {
                return BadRequest("Fetching movies failed...!");
            }

            var mappedMovies = mMapper.Map<IList<DisplayMovie>>(fetchedMovies);

            return Ok(new
            {
                Movies = mappedMovies,
                Count = moviesCount
            });
        }

        [HttpGet]
        public ActionResult<DisplayMovie> GetById([FromQuery] Guid id)
        {
            //movie => movie.Status == (int)EntityStatus.ACTIVE
            var movieRepo = new MovieRepo();
            var fetchedMovie = movieRepo.GetList(movie => movie.Id == id, new[]
                                {
                                    $"{nameof(Movie.TagList)}.{nameof(TagsMovieAssignment.Tag)}",
                                    $"{nameof(Movie.ActorList)}.{nameof(MovieActorAssignment.Actor)}",
                                    $"{nameof(Movie.Category)}"
                                });
            if (fetchedMovie == null)
            {
                return NotFound("Movie with this id doesn't exist...!");
            }

            var mappedMovie = mMapper.Map<IList<DisplayMovie>>(fetchedMovie);

            return Ok(mappedMovie);
        }

        [HttpPost]
        public IActionResult AddTagToMovie([FromQuery] Guid movieId, [FromQuery] Guid tagId)
        {
            var movieRepo = new MovieRepo();
            var tagRepo = new TagRepo();
            var fetchedMovie = movieRepo.Get(movieId);
            if (fetchedMovie == null)
            {
                return NotFound("Movie with this id doesn't exist...!");
            }

            var fetchedTag = tagRepo.Get(tagId);
            if (fetchedTag == null)
            {
                return NotFound("Tag with this id doesn't exist...!");
            }


            var tagMovieRepo = new TagMovieAssignmentRepo();
            var toAdd = new TagsMovieAssignment()
            {
                MovieId = movieId,
                TagId = tagId

            };
            tagMovieRepo.Create(toAdd);

            return Ok(fetchedMovie);
        }

        public IActionResult AddActorToMovie([FromQuery] Guid movieId, [FromQuery] Guid actorId)
        {
            var movieRepo = new MovieRepo();
            var actorRepo = new ActorRepo();
            var fetchedMovie = movieRepo.Get(movieId);
            if (fetchedMovie == null)
            {
                return NotFound("Movie with this id doesn't exist...!");
            }

            var fetchedActor = actorRepo.Get(actorId);
            if (fetchedActor == null)
            {
                return NotFound("Actor with this id doesn't exist...!");
            }


            var actorMovieRepo = new ActorMovieAssignmentRepo();
            var toAdd = new MovieActorAssignment()
            {
                MovieId = movieId,
                ActorId = actorId

            };
            actorMovieRepo.Create(toAdd);

            return Ok(fetchedMovie);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input!");
            }

            var categoryRepo = new CategoryRepo();
            var fetchedCategory = categoryRepo.GetAll().FirstOrDefault(c => c.Name == movie.CategoryName);


            if (fetchedCategory == null)
            {
                return BadRequest("This category doesn't exit!");
            }
            

            var movieToAdd = mMapper.Map<Movie>(movie);
            movieToAdd.Status = (int)EntityStatus.ACTIVE;
            movieToAdd.SavedAt = DateTime.UtcNow;
            movieToAdd.CategoryId = fetchedCategory.Id;


            var claimsIdentity = User.Identity as ClaimsIdentity;

            //tagToAdd.SavedBy = Guid.Parse("06e6c8a6-96e6-40a5-8767-7f4d536a2049"); // User.Claims[0];
            var movieRepo = new MovieRepo();
            var createdMovie = movieRepo.Create(movieToAdd);

            if (createdMovie == null)
            {
                return BadRequest("Failed to create movie");
            }

            return Ok(createdMovie);
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
            var movieRepo = new MovieRepo();
            var fetchedMovie = movieRepo.GetAll().FirstOrDefault(movie => movie.Id == id);

            if (fetchedMovie == null)
            {
                return NotFound("Movie with this id doesn't exist...!");
            }

            movieRepo.Delete(fetchedMovie);

            return Ok(fetchedMovie);
        }

        #endregion

        #region WEB specific
        
        public IActionResult GetMoviesByCategories()
        {
            var movieData = new CategoryRepo(mMapper).GetMoviesByCategories(); //UserRepo.CategoryList;
            //return Ok(ResponseFactory.Success(movieList));
            return Ok(ResponseFactory.CreateResponse(true, ResponseCode.Success, movieData));
        }

        #endregion
    }
}
