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
    public class ActorController : ControllerBase
    {
        
        private readonly IMapper mMapper;

        public ActorController(IMapper mapper)
        {
            mMapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ActorModel>> Get()
        {
            var actorRepo = new ActorRepo();
            var fetchedActors = actorRepo.GetAll();
            var actorsCount = actorRepo.Count();

            if (fetchedActors == null && actorsCount < 0)
            {
                return BadRequest("Fetching actors failed...!");
            }

            var mappedActors = mMapper.Map<ActorModel>(fetchedActors);

            return Ok(new {
                Actors = mappedActors,
                Count = actorsCount
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ActorModel> Get(Guid id)
        {
           
            var actorRepo = new ActorRepo();
            var fetchedActor = actorRepo.GetAll().FirstOrDefault(actor => actor.Id == id);

            if (fetchedActor == null)
            {
                return BadRequest("Fetching actor failed...!");
            }

            var mappedActor = mMapper.Map<ActorModel>(fetchedActor);

            return Ok(mappedActor);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ActorModel actor)
        {
            var actorToAdd = new Actor
            {
                Id = new Guid(),
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                SavedAt = DateTime.UtcNow,
                Status = 0
            };

            var actorRepo = new ActorRepo();
            var createdActor = actorRepo.Create(actorToAdd);

            if (createdActor == null)
            {
                return BadRequest("Failed to create actor");
            }

            return Ok(createdActor);
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
