using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoCodeFirst.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
       // public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime LaunchDate { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int RatingCount { get; set; }
        public double Rating { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
        public User SavedBy { get; set; }

        public Category Category { get; set; }
        public List<MovieActorIntermediate> ActorList { get; set; }
        public List<MoviePlaylistIntermediate> PlaylistList { get; set; }
        public List<MovieTagIntermediate> TagList { get; set; }
        //public ICollection<User> UserList { get; set; }
    }
}
