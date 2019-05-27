using System;

namespace Moventure.DataLayer.Models
{
    public class PlaylistMovieAssignment
    {
        public Guid PlaylistId { get; set; }
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
