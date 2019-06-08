using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class MovieModel : MinifiedMovie
    {
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
        public string TrailerUrl { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }

        public ICollection<ActorModel> Actors { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PlaylistModel> Playlists { get; set; }
    }
}
