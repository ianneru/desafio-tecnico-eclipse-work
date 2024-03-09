using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Entities.Usuario>
    {
        Task<Usuario> GetByNome(string nome, CancellationToken cancellationToken);
    }
}
