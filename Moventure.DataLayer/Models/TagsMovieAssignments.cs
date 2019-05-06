using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class TagsMovieAssignments
    {
        public Guid CategoryId { get; set; }
        public Guid MovieId { get; set; }

        public virtual Tags Category { get; set; }
        public virtual Movies Movie { get; set; }
    }
}
