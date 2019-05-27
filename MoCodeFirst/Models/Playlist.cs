using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoCodeFirst.Models
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public Guid UserId { get; set; }
        public DateTime SavedAt { get; set; }

        public User User { get; set; }
        public List<MoviePlaylistIntermediate> MovieList { get; set; }
    }
}
