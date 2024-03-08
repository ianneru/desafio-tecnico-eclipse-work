using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface ITarefaService
    {
        Task UpdateAsync(long id, Entities.Tarefa tarefa, CancellationToken cancellationToken);
        Task<long> CreateAsync(Entities.Tarefa tarefa, CancellationToken cancellationToken);
        Task DeleteAsync(long id, CancellationToken cancellationToken);

        Task<Tarefa> GetByProjeto(long idProjeto, CancellationToken cancellationToken);
    }
}
