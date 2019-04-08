using System;
using System.Collections.Generic;

namespace Moventure.WebApi.Models
{
    public partial class UserMovieAssignments
    {
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }

        public Movies Movie { get; set; }
        public Users User { get; set; }
    }
}
