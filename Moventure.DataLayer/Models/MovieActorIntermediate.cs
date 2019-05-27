using System;

namespace Moventure.DataLayer.Models
{
    public class MovieActorIntermediate
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
