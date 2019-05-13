using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Moventure.DataLayer.Authentication
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
