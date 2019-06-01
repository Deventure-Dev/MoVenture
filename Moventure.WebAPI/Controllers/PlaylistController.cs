using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;

namespace Moventure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {

        private readonly IMapper mMapper;

        public PlaylistController(IMapper mapper)
        {
            mMapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Playlist>> Get()
        {
            var playlistRepo = new PlaylistRepo();
            var fetchedPlaylists = playlistRepo.GetAll();
            var playlistsCount = playlistRepo.Count();

            if (fetchedPlaylists == null && playlistsCount < 0)
            {
                return BadRequest("Fetching playlists failed...!");
            }

            var mappedPlaylists = mMapper.Map<Playlist>(fetchedPlaylists);

            return Ok(new
            {
                Playlists = mappedPlaylists,
                Count = playlistsCount
            });
      
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Playlist> Get(Guid id)
        {
            var playlistRepo = new PlaylistRepo();
            var fetchedPlaylist = playlistRepo.Get(id);

            if (fetchedPlaylist == null)
            {
                return BadRequest("Fetching playlist failed...!");
            }

            var mappedPlaylist = mMapper.Map<Playlist>(fetchedPlaylist);

            return Ok(mappedPlaylist);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Playlist playlist)
        {
            var playlistToAdd = new Playlist
            {
                Id = new Guid(),
                Name = playlist.Name,
                SavedAt = DateTime.UtcNow
               
            };

            var playlistRep = new PlaylistRepo();
            var createdPlaylist = playlistRep.Create(playlistToAdd);

            if (createdPlaylist == null)
            {
                return BadRequest("Creating playlist failed...!");
            }

            return Ok(createdPlaylist);
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
