using Application.Dtos;

namespace Application.Facades.Interfaces
{
    public interface ITarefaComentarioFacade
    {
        Task<long> CreateAsync(TarefaComentarioRequestDto tarefaComentarioRequestDto, CancellationToken cancellationToken);

        Task<IEnumerable<TarefaComentarioResponseDto>> GetByTarefa(long idProjeto, CancellationToken cancellationToken);
    }
}
