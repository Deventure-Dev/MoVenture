using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moventure.DataLayer.Models;
using Moventure.DataLayer.ViewModels;

namespace Moventure.WebAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View("AuthView");
        }

        // /register
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
            }
            return Ok(new { Username = user.UserName });
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            /*var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds,
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new
                {
                    token = tokenHandler.WriteToken(token)

                });
            }
            return Unauthorized();*/
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id)
                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                    claims: claim,
                  issuer: _configuration["Jwt:Site"],
                  audience: _configuration["Jwt:Site"],
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(
                  new
                  {
                      token = new JwtSecurityTokenHandler().WriteToken(token),
                      expiration = token.ValidTo
                  });
            }
            return Unauthorized();
        }
    }

}