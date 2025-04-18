using Microsoft.AspNetCore.Mvc;
using ProjetoDBZ.Data;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagensController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;            
        }

        [HttpPost]
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