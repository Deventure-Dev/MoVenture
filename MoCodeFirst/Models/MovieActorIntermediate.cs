using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoCodeFirst.Models
{
    public class MovieActorIntermediate
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
