using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface ITarefaComentarioService
    {
        Task<long> CreateAsync(Entities.TarefaComentario tarefaComentario, Tarefa? tarefa, CancellationToken cancellationToken);

        Task<IEnumerable<TarefaComentario>> GetByTarefa(long idTarefa, CancellationToken cancellationToken);
    }
}
