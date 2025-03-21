using DesafioPGESE.Domain.Entities;

namespace DesafioPGESE.Domain.Interfaces.Services
{
    public interface IDocumentoService
    {
        Task<IEnumerable<Documento>> GetByProcessoIdAsync(Guid numUnico);
        Task AddAsync(Guid numUnico, Documento documento);
        Task DeleteAsync(int id);
    }
}
