using System;
using System.Collections.Generic;

namespace LoginSample.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Playlists = new HashSet<Playlists>();
            UserMovieAssignments = new HashSet<UserMovieAssignments>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Playlists> Playlists { get; set; }
        public ICollection<UserMovieAssignments> UserMovieAssignments { get; set; }
    }
}
