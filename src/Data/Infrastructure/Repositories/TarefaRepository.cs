using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContext;

namespace Infrastructure.Repositories
{
    public class TarefaRepository(Context context) : RepositoryBase<Tarefa>(context),ITarefaRepository
    {

    }
}
