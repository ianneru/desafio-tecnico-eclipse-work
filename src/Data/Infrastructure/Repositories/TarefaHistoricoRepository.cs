using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TarefaHistoricoRepository(Context context) : RepositoryBase<TarefaHistorico>(context),ITarefaHistoricoRepository
    {

    }
}
