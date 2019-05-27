using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoCodeFirst.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Movie> MovieList { get; set; }
    }
}
