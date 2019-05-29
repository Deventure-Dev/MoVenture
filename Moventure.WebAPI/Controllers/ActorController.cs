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

    public class ActorController : ControllerBase
    {

        private readonly IMapper mMapper;

        public ActorController(IMapper mapper)
        {
            mMapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            var actorRepo = new ActorRepo();
            var fetchedActors = actorRepo.GetAll();
            var actorsCount = actorRepo.Count();

            if (fetchedActors == null && actorsCount < 0)
            {
                return BadRequest("Fetching actors failed...!");
            }

            var mappedActors = mMapper.Map<IList<ActorModel>>(fetchedActors);

            return Ok(new
            {
                Actors = mappedActors,
                Count = actorsCount
            });
        }

        // GET api/values/5
        [HttpGet]
        public ActionResult<ActorModel> GetById([FromQuery] Guid id)
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
        public IActionResult Create([FromBody] ActorModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input!");
            }

            var actorToAdd = mMapper.Map<Actor>(model);

            actorToAdd.Id = new Guid();
            actorToAdd.Status = (int)EntityStatus.ACTIVE;
            actorToAdd.SavedAt = DateTime.UtcNow;

            var actorRepo = new ActorRepo();
            var createdActor = actorRepo.Create(actorToAdd);

            if (createdActor == null)
            {
                return BadRequest("Failed to create actor");
            }

            return Ok(createdActor);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put(Guid id)
        {
            ActorModel actorUpdate = new ActorModel();
            actorUpdate.Id = Guid.Parse("dbff522a-fcff-409f-a34d-2834db37aeb9");
            actorUpdate.LastName = "Micea";
            actorUpdate.FirstName = "Floare";

            var actorRepo = new ActorRepo();
            var fetchedActor = actorRepo.GetAll().FirstOrDefault(actor => actor.Id == id);

            if(fetchedActor == null)
            {
                return NotFound("Actor with this id doesnt'n exist");
            }

            var actorToUpdate = mMapper.Map<Actor>(actorUpdate);
            actorRepo.Update(actorToUpdate);
            //var cucu = mMapper.Map<Actor>(actorToAdd);
            //var actorToUpdate = actorRepo.Create(cucu);


            return Ok(true);
        }

        // DELETE api/values/5
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var actorRepo = new ActorRepo();
            var fetchedActor = actorRepo.GetAll().FirstOrDefault(actor => actor.Id == id);

            if(fetchedActor == null)
            {
                return NotFound("Actor with this id doesn't exist");
            }

            actorRepo.Delete(fetchedActor);

            return Ok(fetchedActor);
        }
    }
}
