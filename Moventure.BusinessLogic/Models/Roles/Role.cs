using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models.Roles
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
