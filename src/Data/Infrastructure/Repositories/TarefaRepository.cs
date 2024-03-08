using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TarefaRepository(Context context) : RepositoryBase<Tarefa>(context),ITarefaRepository
    {
        public async Task<IEnumerable<Tarefa>> GetByProjeto(long idProjeto, CancellationToken cancellationToken)
        {
            return await DbContext
                    .Set<Tarefa>()
                    .Where(o => o.IdProjeto == idProjeto)
                    .ToListAsync();
        }
    }
}
