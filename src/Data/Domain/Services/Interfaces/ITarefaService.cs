using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tuple<string, object, object>>> UpdateAsync(long id, Tarefa tarefa, Projeto? projeto, CancellationToken cancellationToken);
        Task<long> CreateAsync(Entities.Tarefa tarefa, Projeto? projeto, CancellationToken cancellationToken);
        Task DeleteAsync(long id, CancellationToken cancellationToken);

        Task<IEnumerable<Tarefa>> GetByProjeto(long idProjeto, CancellationToken cancellationToken);

        Task<Tarefa> GetById(long id, CancellationToken cancellationToken);
    }
}
