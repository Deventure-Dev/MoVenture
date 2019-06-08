using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class Movie
    {
        public Guid Id { get; set; }
        //public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime LaunchDate { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int RatingCount { get; set; }
        public double Rating { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }

        public virtual User SavedBy { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<MovieActorAssignment> ActorList { get; set; }
        public virtual ICollection<PlaylistMovieAssignment> PlaylistList { get; set; }
        public virtual ICollection<TagsMovieAssignment> TagList { get; set; }
        //public ICollection<User> UserList { get; set; }
    }
}
