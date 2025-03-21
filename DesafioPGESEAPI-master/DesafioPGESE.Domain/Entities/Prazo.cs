namespace DesafioPGESE.Domain.Entities
{
    public class Prazo : BaseModel
    {
        public int Id { get; set; }
        public Guid NumUnico { get; set; }
        public ProcessoJuridico ProcessoJuridico { get; set; }
        public string Tipo { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataVencimento { get; set; }

    }
}
