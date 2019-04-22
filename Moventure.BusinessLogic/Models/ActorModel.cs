using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public DateTime SavedAt { get; set; }
    }
}
