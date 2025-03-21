namespace DesafioPGESE.Domain.Interfaces.Repositories
{
    public interface IDistribuicaoProcessoRepository
    {
        Task TransferirProcessoAsync(Guid numUnico, int procuradorNovoId);
    }
}
