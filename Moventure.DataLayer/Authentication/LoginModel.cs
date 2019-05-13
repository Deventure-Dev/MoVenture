using Microsoft.AspNetCore.Identity;
using System;

namespace Moventure.DataLayer.Authentication
{
    public class LoginModel : IdentityUser<Guid>
    {
        public string Password { get; set; }
    }
}
