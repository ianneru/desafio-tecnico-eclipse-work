using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITarefaComentarioRepository : IRepositoryBase<Entities.TarefaComentario>
    {
        Task<IEnumerable<TarefaComentario>> GetByTarefa(long idTarefa, CancellationToken cancellationToken);
    }
}
