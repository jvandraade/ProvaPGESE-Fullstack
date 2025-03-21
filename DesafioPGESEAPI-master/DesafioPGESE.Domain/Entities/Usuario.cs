﻿namespace DesafioPGESE.Domain.Entities
{
    public class Usuario : BaseModel
    {
        public Usuario()
        {
            CreatedAt = DateTime.Now;
            Status = "Ativo";
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string? CodigoOAB { get; set; }
        public string? Telefone { get; set; }

    }
}
