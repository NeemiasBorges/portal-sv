using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Services.DTO.Cliente;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:Secret"];
        }

        public string GenerateToken(ClienteDTO cliente)
        {
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("clienteid", cliente.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);

            return tokenHandler.WriteToken(token);
        }
    }
}
