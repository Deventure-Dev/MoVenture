using System;
using System.Collections.Generic;

namespace Moventure.WebApi.Models
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
        public DateTime SavedAt { get; set; }
        public int Status { get; set; }

        public ICollection<ActorMovieAssignments> ActorMovieAssignments { get; set; }
    }
}
