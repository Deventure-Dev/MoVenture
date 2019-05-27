using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventure.DataLayer.Models
{
    public partial class Comment
    {
        public Guid Id { get; set; }
        public string CommentMessage { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
        // public Guid MovieId { get; set; }
        //public Guid SavedBy { get; set; }

        public virtual User SavedByNavigation { get; set; }
        public virtual Movie SavedAtMovie { get; set; }
    }
}
