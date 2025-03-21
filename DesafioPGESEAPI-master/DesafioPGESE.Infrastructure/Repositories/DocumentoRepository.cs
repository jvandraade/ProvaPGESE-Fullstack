using DesafioPGESE.Domain;
using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioPGESE.Infrastructure.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly AppDbContext _context;
        public DocumentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Documento> GetByIdAsync(int id)
        {
            return await _context.Documentos.FindAsync(id);
        }

        public async Task<IEnumerable<Documento>> GetByProcessoIdAsync(Guid numUnico)
        {
            return await _context.Documentos.Where(x => x.NumUnico == numUnico).ToListAsync();
        }

        public async Task AddAsync(Guid numUnico, Documento documento)
        {
            documento.NumUnico = numUnico;
            await _context.Documentos.AddAsync(documento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var documento = await _context.Documentos.FindAsync(id);
            if (documento != null)
            {
                _context.Documentos.Remove(documento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
