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

        public IActionResult GetMoviesByCategories()
        {
            var category1 = new CategoryModel();
            category1.Id = Guid.Parse("a61ffbc0-4bc1-46f5-b1d7-19077911fe29");
            category1.Name = "Action";
            category1.SavedAt = new DateTime();

            var category2 = new CategoryModel();
            category2.Id = Guid.Parse("4031ea58-b7b9-4dee-8e01-32b92d0e6367");
            category2.Name = "Drama";
            category2.SavedAt = new DateTime();




            var movie1 = new MinifiedMovie();
            movie1.Id = Guid.Parse("95f90c86-2d30-42ff-bd0c-fadac0f26a14");
            movie1.Title = "Mr. Nobody";
            movie1.Rating = 5;
            movie1.PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTg4ODkzMDQ3Nl5BMl5BanBnXkFtZTgwNTEwMTkxMDE@._V1_.jpg";

            var movie2 = new MinifiedMovie();
            movie2.Id = Guid.Parse("3d950a14-009a-4968-abf9-e940acf19be6");
            movie2.Title = "Hary Potter";
            movie2.Rating = 4;
            movie2.PictureUrl = "https://timedotcom.files.wordpress.com/2014/07/301386_full1.jpg";

            var tag1 = new Tag();
            tag1.Id = Guid.Parse("9dbb38f3-b16f-4579-8b65-d3f5269484e3");
            tag1.Name = "sci fi";
            var tagsList = new List<Tag>();
            tagsList.Add(tag1);
            movie1.Tags = tagsList;
            movie2.Tags = tagsList;



            List<MinifiedMovie> movieList = new List<MinifiedMovie>();
            movieList.Add(movie1);
            movieList.Add(movie2);

            //return Ok(ResponseFactory.Success(movieList));
            return Ok(ResponseFactory.CreateResponse(true, ResponseCode.Success, movieList));
        }

        #endregion
    }
}
