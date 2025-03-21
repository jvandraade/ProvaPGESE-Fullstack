using DesafioPGESE.Domain.Entities;

namespace DesafioPGESE.Domain.Interfaces.Services
{
    public interface IProcessoJuridicoService
    {
        Task<ProcessoJuridico> GetByIdAsync(Guid numUnico);
        Task<IEnumerable<ProcessoJuridico>> GetAllByProcuradorAsync(int procuradorId);
        Task AddAsync(ProcessoJuridico processoJuridico);
        Task UpdateAsync(ProcessoJuridico processoJuridico);
        Task DeleteAsync(Guid numUnico);
    }
}
