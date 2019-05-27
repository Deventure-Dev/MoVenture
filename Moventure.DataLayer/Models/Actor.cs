using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventure.DataLayer.Models
{
    public partial class Actor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
        public virtual ICollection<MovieActorIntermediate> MovieList { get; set; }

    }
}
