using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Movie> MovieList { get; set; }
    }
}
