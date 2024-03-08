using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITarefaRepository : IRepositoryBase<Entities.Tarefa>
    {
        Task<IEnumerable<Tarefa>> GetByProjeto(long idProjeto,CancellationToken cancellationToken);
    }
}
