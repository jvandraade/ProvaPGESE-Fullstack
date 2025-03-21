using DesafioPGESE.Domain.Entities;

namespace DesafioPGESE.Domain.Interfaces.Repositories
{
    public interface IPrazosRepository
    {
        Task <IEnumerable<Prazo>> GetByProcessoIdAsync(Guid numUnico);
        Task AddAsync(Guid numUnico, Prazo prazo);
        Task UpdateAsync(Prazo prazo);
        Task DeleteAsync(int id);
    }
}
