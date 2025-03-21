using DesafioPGESE.Domain.Entities;

namespace DesafioPGESE.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<Usuario> AuthenticateAsync(string cpf, string senha);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}
