using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
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

        public string GenerateToken(string userId)
        {
            // Implementar a lógica para gerar o token JWT aqui
            // Isso geralmente envolve criar um token assinado com uma chave secreta e incluir informações do usuário
            throw new NotImplementedException();
        }
    }    
}