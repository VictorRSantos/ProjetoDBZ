using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(model == null){
                return BadRequest("Solicitação do cliente inválida.");
            }

            if(model.UserName == "victor" && model.Password == "123456")
            {

                var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecrectKey@345"));
                var signingCredentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "DBZ",
                    audience: "http://localhost:5076",
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { token = tokenString });
            }else{                
                return Unauthorized("Usuário ou senha inválidos.");
            }

        }
        
    }

}