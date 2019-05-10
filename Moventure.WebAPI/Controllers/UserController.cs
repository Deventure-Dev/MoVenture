using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace Moventure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mMapper;
        
        public UserController(IMapper mapper)
        {
            mMapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var userRepo = new UserRepo();
            var fetchedUsers = userRepo.GetAll();
            var userCount = userRepo.Count();

            if (fetchedUsers == null)
            {
                return BadRequest("Failed to fetch users");
            }

            var mappedUsers = mMapper.Map<User>(fetchedUsers);

            return Ok(new
            {
                Users = mappedUsers,
                Count = userCount
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {
            var userRepo = new UserRepo();

            var fetchedUser = userRepo.GetAll().FirstOrDefault(user => user.Id == id);

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
