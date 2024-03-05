using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IProjetoService
    {
        Task UpdateAsync(long id, Entities.Projeto projeto, CancellationToken cancellationToken);
        Task<long> CreateAsync(Entities.Projeto projeto, CancellationToken cancellationToken);
        Task DeleteAsync(long id, CancellationToken cancellationToken);

        Task<IEnumerable<Projeto>> GetAll(CancellationToken cancellationToken);
    }
}
