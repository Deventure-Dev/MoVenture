using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Deventure.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moventure.BusinessLogic.Models;
//using Moventure.BusinessLogic.Models;
using Moventure.BusinessLogic.Repo;
using Moventure.DataLayer.Models;
using EntityStatus = Moventure.BusinessLogic.Models.EntityStatus;

namespace Moventure.WebAPI.Controllers
{
    public class PlaylistController : Controller
    {
    

        private readonly IMapper mMapper;

        public PlaylistController(IMapper mapper)
        {
            mMapper = mapper;
        }

        public IActionResult Index()
        {
            return View("PlaylistView");
        }

        [Authorize]
        // GET api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            var playlistRepo = new PlaylistRepo();
            //var fetchedPlaylists = playlistRepo.GetAll();
            var fetchedPlaylists = playlistRepo.GetList(p => p.Status == (int)EntityStatus.ACTIVE, new[] {
               $"{nameof(Playlist.MovieList)}.{nameof(PlaylistMovieAssignment.Movie)}"
            });
            var playlistsCount = playlistRepo.Count();

            if (fetchedPlaylists == null && playlistsCount < 0)
            {
                return BadRequest("Fetching playlists failed...!");
            }

            var mappedPlaylists = mMapper.Map<IList<DisplayPlaylist>>(fetchedPlaylists);

            return Ok(new
            {
                Playlists = mappedPlaylists,
                Count = playlistsCount
            });
      
        }

        [Authorize]
        // GET api/values/5
        [HttpGet]
        public ActionResult<Playlist> GetById([FromQuery] Guid playlistId)
        {
            var playlistRepo = new PlaylistRepo();
            var fetchedPlaylist = playlistRepo.Get(playlistId);

            if (fetchedPlaylist == null)
            {
                return BadRequest("Fetching playlist failed...!");
            }

            var mappedPlaylist = mMapper.Map<PlaylistModel>(fetchedPlaylist);

            return Ok(mappedPlaylist);
        }


        [Authorize]
        // GET api/values/5
        [HttpGet]
        public ActionResult<Playlist> GetByName([FromQuery] string playlistName)
        {
            var playlistRepo = new PlaylistRepo();
            var fetchedPlaylist = playlistRepo.GetList(p => p.Name == playlistName);

            if (fetchedPlaylist == null)
            {
                return BadRequest("Fetching playlist failed...!");
            }

            return Ok(fetchedPlaylist);
        }

        [Authorize]
        // POST api/values
        [HttpPost]
        public ActionResult Create([FromBody] PlaylistModel playlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input!");
            }

            var playlistToAdd = mMapper.Map<DataLayer.Models.Playlist>(playlist);
            playlistToAdd.UserId = playlist.UserId;
            playlistToAdd.Id = Guid.NewGuid();
            playlistToAdd.SavedAt = DateTime.UtcNow;
            playlistToAdd.Status = (int)EntityStatus.ACTIVE;


            var claimsIdentity = User.Identity as ClaimsIdentity;

            //tagToAdd.SavedBy = Guid.Parse("06e6c8a6-96e6-40a5-8767-7f4d536a2049"); // User.Claims[0];
            var playlistRepo = new PlaylistRepo();
            var createdPlaylist = playlistRepo.Create(playlistToAdd);

            if (createdPlaylist == null)
            {
                return BadRequest("Failed to create playlist");
            }

            return Ok(createdPlaylist);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddMovieToPlaylist([FromQuery] Guid movieId, [FromQuery] Guid playlistId)
        {
            var movieRepo = new MovieRepo();
            var playlistRepo = new PlaylistRepo();
            var fetchedMovie = movieRepo.Get(movieId);
            if (fetchedMovie == null)
            {
                return NotFound("Movie with this id doesn't exist...!");
            }

            var fetchedPlaylist = playlistRepo.Get(playlistId);
            if (fetchedPlaylist == null)
            {
                return NotFound("Playlist with this id doesn't exist...!");
            }


            var playlistMovieRepo = new PlaylistMovieAssignmentRepo();
            var toAdd = new PlaylistMovieAssignment()
            {
                MovieId = movieId,
                PlaylistId = playlistId

            };
            playlistMovieRepo.Create(toAdd);

            return Ok(fetchedPlaylist);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetByUserId([FromQuery] Guid userId)
        {
            var playlistRepo = new PlaylistRepo();
            //var fetchedPlaylists = playlistRepo.GetAll();
            var fetchedPlaylists = playlistRepo.GetList(p => p.Status == (int)EntityStatus.ACTIVE && p.UserId == userId, new[] {
               $"{nameof(Playlist.MovieList)}.{nameof(PlaylistMovieAssignment.Movie)}"
            });
            var playlistsCount = playlistRepo.Count(p => p.UserId == userId);

            if (fetchedPlaylists == null && playlistsCount < 0)
            {
                return BadRequest("Fetching playlists failed...!");
            }

            var mappedPlaylists = mMapper.Map<IList<DisplayPlaylist>>(fetchedPlaylists);

            return Ok(new
            {
                Playlists = mappedPlaylists, 
                Count = playlistsCount
            });

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
