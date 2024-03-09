using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        public async Task<Usuario> GetByNome(string nome, CancellationToken cancellationToken)
        {
            var usuario = await usuarioRepository.GetByNome(nome, cancellationToken);

            return usuario;
        }
    }
}
