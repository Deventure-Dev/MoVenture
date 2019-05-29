using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class TagsMovieAssignmentModel
    {
    public Guid TagId { get; set; }
    public Guid MovieId { get; set; }
    //public virtual MovieModel Movie { get; set; }
    //public virtual TagModel Tag { get; set; }
    }
}
