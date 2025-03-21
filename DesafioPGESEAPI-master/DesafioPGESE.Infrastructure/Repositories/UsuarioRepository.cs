using DesafioPGESE.Domain;
using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioPGESE.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> GetByCPFAsync(string cpf)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.CPF == cpf);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            var usuarioBanco = await _context.Usuarios.FindAsync(usuario.Id);
            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.CPF = usuario.CPF;
            usuarioBanco.Senha = usuario.Senha;
            usuarioBanco.Tipo = usuario.Tipo;
            usuarioBanco.Email = usuario.Email;
            usuarioBanco.CodigoOAB = usuario.CodigoOAB;
            usuarioBanco.Telefone = usuario.Telefone;
            usuarioBanco.Status = usuario.Status;
            usuarioBanco.UpdatedAt = DateTime.Now;
            usuarioBanco.UpdatedBy = usuario.UpdatedBy;
            _context.Usuarios.Update(usuarioBanco);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null) 
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
