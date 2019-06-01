using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class DisplayCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<DisplayMovie> MovieList { get; set; }
    }
}
