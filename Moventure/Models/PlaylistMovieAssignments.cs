using System;
using System.Collections.Generic;

namespace Moventure.WebApi.Models
{
    public partial class PlaylistMovieAssignments
    {
        public Guid PlaylistId { get; set; }
        public Guid MovieId { get; set; }

        public Movies Movie { get; set; }
    }
}
