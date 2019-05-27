using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventure.DataLayer.Models
{
    public class MoviePlaylistIntermediate
    {
        public Guid PlaylistId { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Playlist Playlist { get; set; }
    }
}
