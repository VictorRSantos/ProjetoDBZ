
using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.src.Core.Entities;
using ProjetoDBZ.src.Core.Interfaces;
using ProjetoDBZ.src.Infrastructure.Persistence;

namespace ProjetoDBZ.src.Infrastructure.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly AppDbContext _context;

        public PersonagemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddPersonagemAsync(Personagem personagem)
        {
            await _context.DBZ.AddAsync(personagem);            
            await _context.SaveChangesAsync();
        }

        public Task DeletePersonagemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Personagem>> GetAllPersonagensAsync() =>
            await _context.DBZ.ToListAsync();

        public async Task<Personagem> GetPersonagemByIdAsync(int id) =>
            await _context.DBZ.FindAsync(id);

        public Task UpdatePersonagemAsync(Personagem personagem)
        {
            throw new NotImplementedException();
        }
    }
}