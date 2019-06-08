using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class PlaylistsMovieAssignmentModel
    {
        public Guid PlaylistId { get; set; }
        public Guid MovieId { get; set; }
    }
}
