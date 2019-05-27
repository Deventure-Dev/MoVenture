using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Models
{
    public partial class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime SavedAt { get; set; }
        public int Status { get; set; }

        public virtual User SavedBy { get; set; }
        public virtual ICollection<MovieTagIntermediate> MovieList { get; set; }
    }
}
