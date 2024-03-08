using Application.Dtos;

namespace Application.Facades.Interfaces
{
    public interface ITarefaFacade
    {
        Task<long> CreateAsync(TarefaRequestDto tarefaRequestDto, CancellationToken cancellationToken);
        Task UpdateAsync(long id, TarefaRequestDto tarefaRequestDto, CancellationToken cancellationToken);
        Task DeleteAsync(long id, CancellationToken cancellationToken);

        Task<TarefaResponseDto> GetByProjeto(long idProjeto, CancellationToken cancellationToken);
    }
}
