using DesafioPGESE.Domain.Entities;

namespace DesafioPGESE.Domain.Interfaces.Repositories
{
    public interface IDocumentoRepository
    {
        Task<IEnumerable<Documento>> GetByProcessoIdAsync(Guid numUnico);
        Task AddAsync(Guid numUnico, Documento documento);
        Task DeleteAsync(int id);
    }
}
