using System;
using System.Collections.Generic;

namespace LoginSample.Models
{
    public partial class ActorMovieAssignments
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }

        public Actors Actor { get; set; }
        public Movies Movie { get; set; }
    }
}
