using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Repositories;
using DesafioPGESE.Domain.Interfaces.Services;

namespace DesafioPGESE.Application.Services
{
    public class DocumentoService : IDocumentoService
    {
        private readonly IDocumentoRepository _documentoRepository;
        public DocumentoService(IDocumentoRepository documentoRepository)
        {
            _documentoRepository = documentoRepository;
        }

        public async Task<IEnumerable<Documento>> GetByProcessoIdAsync(Guid numUnico)
        {
            return await _documentoRepository.GetByProcessoIdAsync(numUnico);
        }

        public async Task AddAsync(Guid numUnico, Documento documento)
        {
            await _documentoRepository.AddAsync(numUnico, documento);
        }

        public async Task DeleteAsync(int id)
        {
            await _documentoRepository.DeleteAsync(id);
        }
    }
}
