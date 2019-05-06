using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class ActorMovieAssignments
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }

        public virtual Actors Actor { get; set; }
        public virtual Movies Movie { get; set; }
    }
}
