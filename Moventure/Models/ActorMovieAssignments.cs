using System;
using System.Collections.Generic;

namespace Moventure.WebApi.Models
{
    public partial class ActorMovieAssignments
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }

        public Actors Actor { get; set; }
        public Movies Movie { get; set; }
    }
}
