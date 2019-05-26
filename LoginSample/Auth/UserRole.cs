using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSample.Auth
{
    public class UserRole : IdentityUserRole<int>
    {
        public AuthUser User { get; set; }
        public AuthRole Role { get; set; }
    }
}
