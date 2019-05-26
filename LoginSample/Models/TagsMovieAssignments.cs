using System;
using System.Collections.Generic;

namespace LoginSample.Models
{
    public partial class TagsMovieAssignments
    {
        public Guid CategoryId { get; set; }
        public Guid MovieId { get; set; }

        public Tags Category { get; set; }
        public Movies Movie { get; set; }
    }
}
