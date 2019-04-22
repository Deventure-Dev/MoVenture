using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime SavedAt { get; set; }
    }
}
