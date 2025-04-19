using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoDBZ.src.Core.Entities;
using ProjetoDBZ.src.Core.Interfaces;

namespace ProjetoDBZ.src.Application.Services
{
    public class PersonagemService
    {
        private readonly IPersonagemRepository _personagemRepository;
        
        public PersonagemService(IPersonagemRepository personagemRepository)
        {
            _personagemRepository = personagemRepository;
        }
        public async Task<List<Personagem>> GetAllPersonagensAsync()
        {
            return await _personagemRepository.GetAllPersonagensAsync();
        }

        public async Task<Personagem> GetPersonagemByIdAsync(int id)
        {
            return await _personagemRepository.GetPersonagemByIdAsync(id);
        }
        public async Task AddPersonagemAsync(Personagem personagem)
        {
            await _personagemRepository.AddPersonagemAsync(personagem);
        }
        public async Task UpdatePersonagemAsync(Personagem personagem)
        {
            await _personagemRepository.UpdatePersonagemAsync(personagem);
        }
        public async Task DeletePersonagemAsync(int id)
        {
            await _personagemRepository.DeletePersonagemAsync(id);
        }
        public async Task<bool> PersonagemExistsAsync(int id)
        {
            var personagem = await _personagemRepository.GetPersonagemByIdAsync(id);
            return personagem != null;
        }
        public async Task<bool> PersonagemExistsByNameAsync(string name)
        {
            var personagens = await _personagemRepository.GetAllPersonagensAsync();
            return personagens.Any(p => p.Nome.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public async Task<bool> PersonagemExistsByIdAndNameAsync(int id, string name)
        {
            var personagem = await _personagemRepository.GetPersonagemByIdAsync(id);
            return personagem != null && personagem.Nome.Equals(name, StringComparison.OrdinalIgnoreCase);
        }                   
    }
}