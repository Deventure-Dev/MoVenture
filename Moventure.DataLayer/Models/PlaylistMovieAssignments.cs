using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class PlaylistMovieAssignments
    {
        public Guid PlaylistId { get; set; }
        public Guid MovieId { get; set; }

        public virtual Movies Movie { get; set; }
    }
}
