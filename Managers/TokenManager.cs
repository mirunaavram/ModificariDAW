using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using test2.Entities;

namespace test2.Managers
{
    public class TokenManager :ITokenManager
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        
        public TokenManager(IConfiguration configuration, UserManager<User> userManager) 
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }
        public async Task<string> GenerateToken(User user)
        {
            var secretKey = configuration.GetSection("Jwt").GetSection("SecretKey").Get<string>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
           
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature); //credentials
            
            var claims = new List<Claim>(); //claim-uri date de security
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }



            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
