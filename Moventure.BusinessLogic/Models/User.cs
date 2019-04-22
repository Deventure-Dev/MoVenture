using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models
{
    public class User
    {
        public Guid Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public Boolean Status;
        public DateTime SavedAt;
        public List<Movie> Movies;
    }
}
