using Microsoft.AspNetCore.Identity;
using Moventure.DataLayer.Models;

namespace Moventure.DataLayer.Authentication
{
    public class UserRole : IdentityUserRole<int>
    {
        public Users User { get; set; }
        public Role Role { get; set; }
    }
}
