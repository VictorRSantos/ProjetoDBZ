using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoDBZ.src.Core.Entities;
using ProjetoDBZ.src.Application.Services;

namespace ProjetoDBZ.src.API.Controllers
{
    [ApiController]
    [Route("api/personagens")]
    [Authorize]
    public class PersonagensController : ControllerBase
    {
        private readonly PersonagemService _personagemService;

        public PersonagensController(PersonagemService personagemService)
        {
            _personagemService = personagemService;            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personagens = await _personagemService.GetAllPersonagensAsync();
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var personagem = await _personagemService.GetPersonagemByIdAsync(id);

            if (personagem == null) return NotFound($"Personagem com ID {id} não encontrado.");
            
            return Ok(personagem);

        }

        [HttpPost]
        public async Task<IActionResult> Create(Personagem personagem)
        {
            if (personagem == null)
            {
                return BadRequest("Personagem não pode ser nulo.");
            }  

            await _personagemService.AddPersonagemAsync(personagem);            

            return CreatedAtAction(nameof(GetById), new {id = personagem.Id}, personagem);
        }
        
    }
}