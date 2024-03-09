using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository(Context context) : RepositoryBase<Usuario>(context),IUsuarioRepository
    {
        public async Task<Usuario> GetByNome(string nome, CancellationToken cancellationToken)
        {
            return await DbContext
                        .Set<Usuario>()
                        .FirstOrDefaultAsync(p => p.Nome == nome, cancellationToken);
        }
    }
}
