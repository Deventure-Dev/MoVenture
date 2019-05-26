using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LoginSample.Auth
{
    public class AuthRole : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
