using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{

    public class DisplayMovie
    {
        public DisplayMovie()
        {
            Tags = new List<string>();
        }

        public Guid Id { get; set; }
        public double Rating { get; set; }
        public string PictureUrl { get; set; }
        public string Title { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
