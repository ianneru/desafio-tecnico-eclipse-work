using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GetByNome(string nome, CancellationToken cancellationToken);
    }
}
