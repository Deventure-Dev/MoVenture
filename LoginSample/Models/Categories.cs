using System;
using System.Collections.Generic;

namespace LoginSample.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Movies = new HashSet<Movies>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime SavedAt { get; set; }
        public int Status { get; set; }
        public Guid Savedby { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}
