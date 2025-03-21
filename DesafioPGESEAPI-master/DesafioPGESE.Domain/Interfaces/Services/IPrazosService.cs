using DesafioPGESE.Domain.Entities;

namespace DesafioPGESE.Domain.Interfaces.Services
{
    public interface IPrazosService
    {
        Task<IEnumerable<Prazo>> GetByProcessoIdAsync(Guid numUnico);
        Task AddAsync(Guid numUnico, Prazo prazo);
        Task UpdateAsync(Prazo prazo);
        Task DeleteAsync(int id);
    }
}
