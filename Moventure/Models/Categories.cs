using System;
using System.Collections.Generic;

namespace Moventure.WebApi.Models
{
    public partial class Categories
    {
        public Categories()
        {
            CategoryMovieAssignments = new HashSet<CategoryMovieAssignments>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime SavedAt { get; set; }
        public int Status { get; set; }
        public Guid SavedBy { get; set; }

        public ICollection<CategoryMovieAssignments> CategoryMovieAssignments { get; set; }
    }
}
