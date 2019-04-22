using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Models;

namespace Moventure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static DateTime today = DateTime.Today;
        // GET api/values
        /*[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        [HttpGet]
        public string GetByUserId(Guid userId)
        {

            /* var movieList = new List<MinifiedMovie>()
             {
                 new MinifiedMovie
                 {
                     Id = Guid.NewGuid(),
                     Title = "Mr. Nobody",
                     PictureUrl = "https://images-na.ssl-images-amazon.com/images/I/91WY2zIvzzL._SY445_.jpg",
                     Rating = 4.7,
                     Length = 157,
                     MainCategory = new Category {
                         Id = Guid.NewGuid(),
                         Name = "Drama",
                         SavedAt = today,
                         SavedBy = new User
                         {
                             Email = "test@yahoo.com",
                             FirstName = "Mircea",
                             LastName = "Paul",
                             Password = "parola",
                             SavedAt = today
                         }
                     },
                     Tags = {
                         new Tag
                         {
                            Id = Guid.NewGuid(),
                            Name = "Action",
                            SavedAt = today
                         },
                         new Tag
                         {
                            Id = Guid.NewGuid(),
                            Name = "Action",
                            SavedAt = today
                         }
                     }


                 },
                  new MinifiedMovie
                 {
                     Id = Guid.NewGuid(),
                     Title = "Dark river",
                     PictureUrl = "https://upload.wikimedia.org/wikipedia/en/0/0b/Dark_River_%282017_film%29.png",
                     Rating = 4.2,
                     Length = 175,
                     MainCategory = new Category {
                         Id = Guid.NewGuid(),
                         Name = "Action",
                         SavedAt = today,
                         SavedBy = new User
                         {
                             Email = "asdas@yahoo.com",
                             FirstName = "Guta",
                             LastName = "Nicolae",
                             Password = "gutapassword",
                             SavedAt = today
                         }
                     },
                     Tags = {
                         new Tag
                         {
                            Id = Guid.NewGuid(),
                            Name = "Comedy",
                            SavedAt = today
                         },
                         new Tag
                         {
                            Id = Guid.NewGuid(),
                            Name = "SF",
                            SavedAt = today
                         }
                     }


                 }

             };
             Console.WriteLine(movieList);*/


            // return movieList.FindAll(movie => movie.CreatedBy == userId);
            return "Ana";
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
