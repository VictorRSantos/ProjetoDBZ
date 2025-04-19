using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoDBZ.src.Infrastructure.Persistence;
using ProjetoDBZ.src.Core.Entities;

namespace ProjetoDBZ.src.API.Controllers
{
    [ApiController]
    [Route("api/personagens")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagensController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;            
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddPersonagem(Personagem personagem)
        {
            if (personagem == null)
            {
                return BadRequest("Personagem não pode ser nulo.");
            }           
    
            await _appDbContext.DBZ.AddAsync(personagem);
            await _appDbContext.SaveChangesAsync();

            return Ok(personagem);
        }
        
    }
}