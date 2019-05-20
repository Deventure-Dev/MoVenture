using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Authentication;
using Moventure.DataLayer.Models;
using Moventure.Models;
using Moventure.WebAPI.Logic;

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

        [HttpPost("login", Name = "LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //var user = await mUserManager.FindByEmailAsync(model.Email);
            //if (user == null)
            //{
            //    return Unauthorized();
            //}

            //var result = await mSignInManager.CheckPasswordSignInAsync(user, model.Password, false);
            //if (result.Succeeded)
            //{

            //    //uncoment the section to add admins manually
            //    //add user role to user
            //    //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin")); 

            //    await mUserManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));

            //    //var mappedUserToDto = mMapper.Map<User>(user);

            //    return Ok();
            //    //new
            //    //{
            //    //    token = await TokenGenerator.GenerateJwtToken(user, mMapper, mConfig, mUserManager),
            //    //    user = mappedUserToDto,
            //    //});
            //}

            return Unauthorized();
        }


        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register([FromBody] BusinessLogic.Models.User userDto)
        {
            //var user = mMapper.Map<Users>(userDto);

            //var result = await mUserManager.CreateAsync(user, userDto.Password);
            //if (result.Succeeded)
            //{
            //    return StatusCode(201);
            //}

            //return BadRequest(result.Errors);
            return BadRequest();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get()
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
        public ActionResult<Users> Get(string email)
        {
            var userRepo = new UserRepo(null);
            var fetchedUser = userRepo.GetUserData("silviu@yahoo.com");
            if (fetchedUser == null)
            {
                return NotFound();
            }

            var mappedUser = mMapper.Map<Users>(fetchedUser);
            return Ok(mappedUser);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            var userRepo = new UserRepo();
            var userToAdd = new Users
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
