using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoDBZ.src.Core.Interfaces;

namespace ProjetoDBZ.src.Application.Services
{
    public class AuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        
        public string Login(string username, string password)
        {
            // Aqui você deve validar o usuário e a senha com seu banco de dados ou outro serviço de autenticação
            if (username == "victor" && password == "123456")
            {
                // Gera o token JWT se as credenciais estiverem corretas
                return _jwtTokenGenerator.GenerateToken(username);
            }
            else
            {
                throw new UnauthorizedAccessException("Usuário ou senha inválidos.");
            }
        }
    }
}