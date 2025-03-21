using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Repositories;
using DesafioPGESE.Domain.Interfaces.Services;

namespace DesafioPGESE.Application.Services
{
    public class PrazosService : IPrazosService
    {
        private readonly IPrazosRepository _prazosRepository;
        public PrazosService(IPrazosRepository prazosRepository)
        {
            _prazosRepository = prazosRepository;
        }

        public async Task<IEnumerable<Prazo>> GetByProcessoIdAsync(Guid numUnico)
        {
            return await _prazosRepository.GetByProcessoIdAsync(numUnico);
        }

        public async Task AddAsync(Guid numUnico, Prazo prazo)
        {
            await _prazosRepository.AddAsync(numUnico, prazo);
        }

        public async Task UpdateAsync(Prazo prazo)
        {
            await _prazosRepository.UpdateAsync(prazo);
        }

        public async Task DeleteAsync(int id)
        {
            await _prazosRepository.DeleteAsync(id);
        }
    }
}
