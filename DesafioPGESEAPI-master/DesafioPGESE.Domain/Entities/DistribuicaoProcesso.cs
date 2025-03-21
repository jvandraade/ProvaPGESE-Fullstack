namespace DesafioPGESE.Domain.Entities
{
    public class DistribuicaoProcesso
    {
        public Guid NumUnico { get; set; }
        public int ProcuradorAntigoId { get; set; }
        public int ProcuradorNovoId { get; set; }
    }
}
