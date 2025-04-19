using Microsoft.AspNetCore.Mvc;
using ProjetoDBZ.src.Core.Entities;
using ProjetoDBZ.src.Application.Services;

namespace ProjetoDBZ.src.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                if(model == null){
                    return BadRequest("Solicitação do cliente inválida.");
                }                

                var token = _authService.Login(model.UserName, model.Password);

                return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }               

        }
        
    }

}