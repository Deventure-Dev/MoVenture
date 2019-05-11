using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Moventure.WebAPI.Logic
{
    public class TokenGenerator
    {
        public static async Task<string> GenerateJwtToken(Users user, IMapper mapper, IConfiguration config, UserManager<Users> userManager)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            //get all user role claims
            var userRoles = await userManager.GetClaimsAsync(user);

            //add roles to claims
            foreach (var roleClaim in userRoles)
            {
                claims.Add(roleClaim);
            }

            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);

        }
    }
}
