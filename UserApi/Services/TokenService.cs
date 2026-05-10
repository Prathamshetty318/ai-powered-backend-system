using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UserApi.Models;
using Microsoft.Extensions.Options;


namespace UserApi.Services
{
    public class TokenService
    {
        private readonly JwtOptions _options;

        public TokenService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            //throw new Exception("Test exception");

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name)
            };

            var Key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.Key));

            var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}