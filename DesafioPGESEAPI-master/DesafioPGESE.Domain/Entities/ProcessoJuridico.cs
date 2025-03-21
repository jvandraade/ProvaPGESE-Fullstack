namespace DesafioPGESE.Domain.Entities
{
    public class ProcessoJuridico : BaseModel
    {
        public ProcessoJuridico()
        {
            CreatedAt = DateTime.Now;
            Status = "Ativo";
        }
        public Guid NumUnico { get; set; } = Guid.NewGuid();
        public string NumeroProcesso { get; set; }
        public string LocalTramitacao { get; set; }
        public string Assunto { get; set; }
        public int ProcuradorId { get; set; }
        public List<Usuario> Clientes { get; set; } = new List<Usuario>();
    }
}
