using DesafioPGESE.Domain.Interfaces.Repositories;
using DesafioPGESE.Domain.Interfaces.Services;

namespace DesafioPGESE.Application.Services
{
    public class DistribuicaoProcessoService : IDistribuicaoProcessoService
    {
        private readonly IDistribuicaoProcessoRepository _distribuicaoProcessoRepository;
        public DistribuicaoProcessoService(IDistribuicaoProcessoRepository distribuicaoProcessoRepository)
        {
            _distribuicaoProcessoRepository = distribuicaoProcessoRepository;
        }

        public async Task TransferirProcessoAsync(Guid numUnico, int procuradorId)
        {
            await _distribuicaoProcessoRepository.TransferirProcessoAsync(numUnico, procuradorId);
        }
    }
}
