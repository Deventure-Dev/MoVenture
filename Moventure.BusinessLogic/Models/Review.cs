using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Comment Comment { get; set; }
        public Guid MovieId { get; set; }
        public double Rating { get; set; }
        public string PictureUrl { get; set; }
    }
}
