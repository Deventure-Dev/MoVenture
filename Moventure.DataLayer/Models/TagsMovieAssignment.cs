using System;

namespace Moventure.DataLayer.Models
{
    public partial class TagsMovieAssignment
    {
        public Guid TagId { get; set; }
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
