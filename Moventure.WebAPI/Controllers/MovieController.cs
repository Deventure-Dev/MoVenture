using System;
using System.Collections.Generic;
using System.Linq;
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

    //[ApiController]
    public class MovieController : ControllerBase
    {
        private static DateTime today = DateTime.Today;

        private readonly IMapper mMapper;

        public MovieController(IMapper mapper)
        {
            mMapper = mapper;
        }

        #region WEBAPI specific

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("api/[controller]")]
        public ActionResult<Movie> Get(Guid id)
        {
            var movieRepo = new MovieRepo();

            var fetchedMovie = movieRepo.GetAll().FirstOrDefault(movie => movie.Id == id);

            if (fetchedMovie == null)
            {
                return NotFound();
            }

            var mappedMovie = mMapper.Map<Movie>(fetchedMovie);

            return Ok(mappedMovie);
        }

        // GET api/values
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movieRepo = new MovieRepo();
            var fetchedMovies = movieRepo.GetAll();
            var movieCount = movieRepo.Count();

            if (fetchedMovies == null && movieCount < 0)
            {
                return BadRequest("Fetching movies failed....");
            }

            var mappedMovies = mMapper.Map<Movie>(fetchedMovies);

            return Ok(new
            {
                Movies = mappedMovies,
                Count = movieCount
            });

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            var movieRepo = new MovieRepo();
            var movieToAdd = new Movies
            {
                Id = new Guid(),
                Title = movie.Title,
                PictureUrl = movie.PictureUrl,
                Rating = movie.Rating,
                SavedAt = DateTime.UtcNow,
                RatingCount = (int)movie.Rating,
                Status = 0,
                TrailerUrl = movie.TrailerUrl,
                LaunchDate = DateTime.UtcNow

            };

            var createdMovie = movieRepo.Create(movieToAdd);

            if (createdMovie == null)
            {
                return BadRequest("Movie was not created!");
            }

            return Ok(createdMovie);
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

        #endregion

        #region WEB specific

        public IActionResult GetMoviesByCategories(Guid userId)
        {
            List<MinifiedMovie> movieList = new List<MinifiedMovie>();
            movieList.Add(null);
            movieList.Add(null);
            movieList.Add(null);
            movieList.Add(null);
            movieList.Add(null);
            movieList.Add(null);

            //return Ok(ResponseFactory.Success(movieList));
            return Ok(ResponseFactory.CreateResponse(true, ResponseCode.Success, movieList));
        }

        #endregion
    }
}
