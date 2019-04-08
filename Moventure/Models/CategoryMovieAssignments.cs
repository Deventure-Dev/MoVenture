using System;
using System.Collections.Generic;

namespace Moventure.WebApi.Models
{
    public partial class CategoryMovieAssignments
    {
        public Guid CategoryId { get; set; }
        public Guid MovieId { get; set; }

        public Categories Category { get; set; }
        public Movies Movie { get; set; }
    }
}
