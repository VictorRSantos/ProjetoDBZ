using ProjetoDBZ.src.Core.Entities;

namespace ProjetoDBZ.src.Core.Interfaces
{
    public interface IPersonagemRepository
    {
        Task<List<Personagem>> GetAllPersonagensAsync();
        Task<Personagem> GetPersonagemByIdAsync(int id);
        Task AddPersonagemAsync(Personagem personagem);
        Task UpdatePersonagemAsync(Personagem personagem);
        Task DeletePersonagemAsync(int id);        
    }
}