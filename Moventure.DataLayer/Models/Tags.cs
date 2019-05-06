using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class Tags
    {
        public Tags()
        {
            TagsMovieAssignments = new HashSet<TagsMovieAssignments>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime SavedAt { get; set; }
        public int Status { get; set; }
        public Guid SavedBy { get; set; }

        public virtual ICollection<TagsMovieAssignments> TagsMovieAssignments { get; set; }
    }
}
