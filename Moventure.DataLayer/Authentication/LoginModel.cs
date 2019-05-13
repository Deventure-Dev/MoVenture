using Microsoft.AspNetCore.Identity;

namespace Moventure.DataLayer.Authentication
{
    public class LoginModel : IdentityUser<int>
    {
        public string Password { get; set; }
    }
}
