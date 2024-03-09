using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface ITarefaHistoricoService
    {
        Task<long> CreateAsync(Entities.TarefaHistorico tarefaHistorico, Tarefa? tarefa, CancellationToken cancellationToken);

        Task<IEnumerable<TarefaHistorico>> GetByTarefa(long idTarefa, CancellationToken cancellationToken);
    }
}
