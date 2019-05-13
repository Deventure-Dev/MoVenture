using System;
using System.Collections.Generic;

namespace Moventure.BusinessLogic.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public DateTime SavedAt { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
