using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PublishingHouse.WebApi.Auth.Interface;

namespace PublishingHouse.WebApi.Auth.Impl
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public string CreateJwtToken(IdentityUser user, IList<string> roles)
        {
            Console.WriteLine("Configuration Values:");
            foreach (var kvp in configuration.AsEnumerable())
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            // Claims:
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.UserName ?? throw new InvalidOperationException("Identity user username is null")),
                new("id", user.Id),
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Credentials:
            var configurationJwtKey = configuration["Jwt:Key"];
            Console.WriteLine("jwtkey:", configurationJwtKey);
            if (string.IsNullOrEmpty(configurationJwtKey))
            {
                throw new InvalidOperationException("Jwt:Key is not configured.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationJwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Token:
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials);

            Console.WriteLine(token);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
