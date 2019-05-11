using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommentMessage { get; set; }
        public Guid SavedBy { get; set; }
        public Guid MovieId { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
    }
}
