using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContext;

namespace Infrastructure.Repositories
{
    public class ProjetoRepository(Context context) : RepositoryBase<Projeto>(context),IProjetoRepository
    {

    }
}
