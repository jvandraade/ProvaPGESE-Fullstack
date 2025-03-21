using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Repositories;
using DesafioPGESE.Domain.Interfaces.Services;

namespace DesafioPGESE.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<Usuario> AuthenticateAsync(string cpf, string senha)
        {
            var usuario = await _usuarioRepository.GetByCPFAsync(cpf);
            if (usuario != null && usuario.Senha == senha)
                return usuario;
            return null;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }


        public async Task UpdateAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
