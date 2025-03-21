using DesafioPGESE.Domain;
using DesafioPGESE.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioPGESE.Infrastructure.Repositories
{
    public class DistribuicaoProcessoRepository : IDistribuicaoProcessoRepository
    {
        private readonly AppDbContext _context;
        public DistribuicaoProcessoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task TransferirProcessoAsync(Guid numUnico, int procuradorNovoId)
        {
            var processo = await _context.ProcessosJuridicos.FirstOrDefaultAsync(x => x.NumUnico == numUnico);
            
            if ( processo != null)
            {
                processo.ProcuradorId = procuradorNovoId;
                _context.ProcessosJuridicos.Update(processo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
