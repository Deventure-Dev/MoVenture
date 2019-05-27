using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventure.DataLayer.Models
{
    public class MovieTagIntermediate
    {
        public Guid TagId { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Tag Tag { get; set; }
    }
}
