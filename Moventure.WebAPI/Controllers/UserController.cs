using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;
//using Moventure.Models;

namespace Moventure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mMapper;
        //private readonly UserManager<Users> mUserManager;
        //private readonly SignInManager<Users> mSignInManager;
        //private readonly IConfiguration mConfig;

        public UserController(IMapper mapper) //, UserManager<Users> userManager, SignInManager<Users> signInManager, IConfiguration config)
        {
            mMapper = mapper;
            //mUserManager = userManager;
            //mSignInManager = signInManager;
            //mConfig = config;
        }

  


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var userRepo = new UserRepo(null);
            //var fetchedUsers = userRepo.GetAll();
            var userData = userRepo.GetUserData("silviu@yahoo.com");
            var userCount = userRepo.Count();

            if (userData == null)
            {
                return BadRequest("Failed to fetch users");
            }

            //var mappedUsers = mMapper.Map<Users>(fetchedUsers);

            return Ok(userData);
        }

        [HttpGet("{email}")]
        public ActionResult<User> Get(string email)
        {
            var userRepo = new UserRepo(null);
            var fetchedUser = userRepo.GetUserData("silviu@yahoo.com");
            if (fetchedUser == null)
            {
                return NotFound();
            }

            var mappedUser = mMapper.Map<User>(fetchedUser);
            return Ok(mappedUser);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var userRepo = new UserRepo();
            var userToAdd = new User
            {
                Id = new Guid(),

                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                SavedAt = DateTime.UtcNow,
                Status = 0
            };

            var createdUser = userRepo.Create(userToAdd);

            if (createdUser == null)
            {
                return BadRequest("User not created!");
            }

            return Ok(createdUser);

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
