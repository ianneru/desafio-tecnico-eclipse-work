using Application.Dtos;
using Domain.Entities;

namespace Application.Facades.Interfaces
{
    public interface ITarefaHistoricoFacade
    {
        Task<IEnumerable<TarefaHistoricoResponseDto>> GetByTarefa(long idTarefa, CancellationToken cancellationToken);
    }
}
