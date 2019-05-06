using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class Actors
    {
        public Actors()
        {
            ActorMovieAssignments = new HashSet<ActorMovieAssignments>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public DateTime SavedAt { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ActorMovieAssignments> ActorMovieAssignments { get; set; }
    }
}
