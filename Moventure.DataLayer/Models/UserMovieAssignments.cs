using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class UserMovieAssignments
    {
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }

        public virtual Movies Movie { get; set; }
        public virtual Users User { get; set; }
    }
}
