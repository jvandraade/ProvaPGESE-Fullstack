using DesafioPGESE.Domain;
using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioPGESE.Infrastructure.Repositories
{
    public class PrazosRepository : IPrazosRepository
    {
        private readonly AppDbContext _context;
        public PrazosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Prazo> GetByIdAsync(int id)
        {
            return await _context.Prazos.FindAsync(id);
        }

        public async Task<IEnumerable<Prazo>> GetByProcessoIdAsync(Guid numUnico)
        {
            return await _context.Prazos.Where(x => x.NumUnico == numUnico).ToListAsync();
        }

        public async Task AddAsync(Guid numUnico, Prazo prazo)
        {
            prazo.NumUnico = numUnico;
            await _context.Prazos.AddAsync(prazo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prazo prazo)
        {
            _context.Prazos.Update(prazo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var prazo = await _context.Prazos.FindAsync(id);
            if (prazo != null)
            {
                _context.Prazos.Remove(prazo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
