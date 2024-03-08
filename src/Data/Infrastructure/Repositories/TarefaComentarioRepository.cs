using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TarefaComentarioRepository(Context context) : RepositoryBase<TarefaComentario>(context),ITarefaComentarioRepository
    {
        public async Task<IEnumerable<TarefaComentario>> GetByTarefa(long idTarefa, CancellationToken cancellationToken)
        {
            return await DbContext
                    .Set<TarefaComentario>()
                    .Where(o => o.IdTarefa == idTarefa)
                    .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
