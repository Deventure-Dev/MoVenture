using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class Movies
    {
        public Movies()
        {
            ActorMovieAssignments = new HashSet<ActorMovieAssignments>();
            PlaylistMovieAssignments = new HashSet<PlaylistMovieAssignments>();
            TagsMovieAssignments = new HashSet<TagsMovieAssignments>();
            UserMovieAssignments = new HashSet<UserMovieAssignments>();
        }

        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime LaunchDate { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int RatingCount { get; set; }
        public double Rating { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
        public Guid SavedBy { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<ActorMovieAssignments> ActorMovieAssignments { get; set; }
        public virtual ICollection<PlaylistMovieAssignments> PlaylistMovieAssignments { get; set; }
        public virtual ICollection<TagsMovieAssignments> TagsMovieAssignments { get; set; }
        public virtual ICollection<UserMovieAssignments> UserMovieAssignments { get; set; }
    }
}
