using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class CommentModel
    {
        public string CommentMessage { get; set; }
        public Guid MovieId { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
    }
}
