using DesafioPGESE.Domain;
using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioPGESE.Infrastructure.Repositories
{
    public class ProcessoJuridicoRepository : IProcessoJuridicoRepository
    {
        private readonly AppDbContext _context;
        public ProcessoJuridicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProcessoJuridico> GetByIdAsync(Guid numUnico)
        {
            return await _context.ProcessosJuridicos.FindAsync(numUnico);
        }

        public async Task<IEnumerable<ProcessoJuridico>> GetAllByProcuradorAsync(int procuradorId)
        {
            return await _context.ProcessosJuridicos.Where(x => x.ProcuradorId == procuradorId).ToListAsync();
        }

        public async Task AddAsync(ProcessoJuridico processoJuridico)
        {
            await _context.ProcessosJuridicos.AddAsync(processoJuridico);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProcessoJuridico processoJuridico)
        {
            _context.ProcessosJuridicos.Update(processoJuridico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid numUnico)
        {
            var processoJuridico = await _context.ProcessosJuridicos.FindAsync(numUnico);
            if (processoJuridico != null)
            {
                _context.ProcessosJuridicos.Remove(processoJuridico);
                await _context.SaveChangesAsync();
            }
        }
    }
}
