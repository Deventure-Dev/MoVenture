using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoCodeFirst.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime SavedAt { get; set; }
        public int Status { get; set; }
        public Guid Savedby { get; set; }

        public List<Movie> MovieList { get; set; }
    }
}
