namespace DesafioPGESE.Domain.Entities
{
    public class Documento : BaseModel
    {
        public int Id { get; set; }
        public Guid NumUnico { get; set; }
        public ProcessoJuridico ProcessoJuridico { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
    }
}
