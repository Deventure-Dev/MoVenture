using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Moventure.DataLayer.Authentication
{
    public class Role : IdentityRole<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
