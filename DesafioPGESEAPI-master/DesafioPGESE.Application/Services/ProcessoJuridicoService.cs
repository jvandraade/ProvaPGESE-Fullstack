using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Repositories;
using DesafioPGESE.Domain.Interfaces.Services;

namespace DesafioPGESE.Application.Services
{
    public class ProcessoJuridicoService : IProcessoJuridicoService
    {
        private readonly IProcessoJuridicoRepository _processoJuridicoRepository;
        public ProcessoJuridicoService(IProcessoJuridicoRepository processoJuridicoRepository)
        {
            _processoJuridicoRepository = processoJuridicoRepository;
        }

        public async Task<ProcessoJuridico> GetByIdAsync(Guid numUnico)
        {
            return await _processoJuridicoRepository.GetByIdAsync(numUnico);
        }

        public async Task<IEnumerable<ProcessoJuridico>> GetAllByProcuradorAsync(int procuradorId)
        {
            return await _processoJuridicoRepository.GetAllByProcuradorAsync(procuradorId);
        }

        public async Task AddAsync(ProcessoJuridico processoJuridico)
        {
            await _processoJuridicoRepository.AddAsync(processoJuridico);
        }

        public async Task UpdateAsync(ProcessoJuridico processoJuridico)
        {
            await _processoJuridicoRepository.UpdateAsync(processoJuridico);
        }

        public async Task DeleteAsync(Guid numUnico)
        {
            await _processoJuridicoRepository.DeleteAsync(numUnico);
        }
    }
}
