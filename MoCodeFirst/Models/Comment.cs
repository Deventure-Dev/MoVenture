using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoCodeFirst.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommentMessage { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
       // public Guid MovieId { get; set; }
        //public Guid SavedBy { get; set; }

        public User SavedByNavigation { get; set; }
        public Movie SavedAtMovie { get; set; }
    }
}
