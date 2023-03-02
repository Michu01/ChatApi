using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using ChatApi.DTOs;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ChatApi.Services
{
    public class JwtGenerator
    {
        private readonly IConfiguration configuration;

        private readonly UserManager<UserDTO> userManager;

        public JwtGenerator(IConfiguration configuration, UserManager<UserDTO> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }

        public async Task<string> Generate(UserDTO user)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            IList<string> roles = await userManager.GetRolesAsync(user);

            IEnumerable<Claim> claims = new Claim[]
            {
                new(ClaimTypes.NameIdentifier, user.UserName!)
            }.Concat(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            JwtSecurityToken token = new
            (
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
