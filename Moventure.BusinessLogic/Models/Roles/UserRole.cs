using Microsoft.AspNetCore.Identity;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Models.Roles
{
    public class UserRole : IdentityUserRole<int>
    {
        public Users User { get; set; }
        public Role Role { get; set; }
    }
}
