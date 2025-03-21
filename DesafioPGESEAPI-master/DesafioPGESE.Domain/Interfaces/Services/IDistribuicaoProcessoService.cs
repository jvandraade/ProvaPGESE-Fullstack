namespace DesafioPGESE.Domain.Interfaces.Services
{
    public interface IDistribuicaoProcessoService
    {
        Task TransferirProcessoAsync(Guid numUnico, int procuradorNovoId);
    }
}
