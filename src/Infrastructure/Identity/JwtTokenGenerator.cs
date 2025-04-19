using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjetoDBZ.src.Core.Interfaces;
using ProjetoDBZ.src.Shared.Configuration;

namespace ProjetoDBZ.src.Infrastructure.Identity
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _settings;

        public JwtTokenGenerator(IOptions<JwtSettings> options)
        {
            _settings = options.Value;
        }

        public string GenerateToken(string username)
        {
            // Implementar a lógica para gerar o token JWT aqui
            // Isso geralmente envolve criar um token assinado com uma chave secreta e incluir informações do usuário
            var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var signingCredentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                expires: DateTime.Now.AddMinutes(_settings.ExpiresInMinutes),
                signingCredentials: signingCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            
            return tokenString;
        }
    }
}