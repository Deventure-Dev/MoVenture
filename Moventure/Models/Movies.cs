using System;
using System.Collections.Generic;

namespace Moventure.WebApi.Models
{
    public partial class Movies
    {
        public Movies()
        {
            ActorMovieAssignments = new HashSet<ActorMovieAssignments>();
            CategoryMovieAssignments = new HashSet<CategoryMovieAssignments>();
            PlaylistMovieAssignments = new HashSet<PlaylistMovieAssignments>();
            UserMovieAssignments = new HashSet<UserMovieAssignments>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime LaunchDate { get; set; }
        public string PictureUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int RatingCount { get; set; }
        public double Rating { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
        public Guid SavedBy { get; set; }

        public ICollection<ActorMovieAssignments> ActorMovieAssignments { get; set; }
        public ICollection<CategoryMovieAssignments> CategoryMovieAssignments { get; set; }
        public ICollection<PlaylistMovieAssignments> PlaylistMovieAssignments { get; set; }
        public ICollection<UserMovieAssignments> UserMovieAssignments { get; set; }
    }
}
