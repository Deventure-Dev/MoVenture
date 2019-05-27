using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public Guid UserId { get; set; }
        public DateTime SavedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PlaylistMovieAssignment> MovieList { get; set; }
    }
}
