using Application.Dtos;
using Application.Facades.Interfaces;
using AutoMapper;
using Domain.Services;
using Domain.Services.Interfaces;

namespace Application.Facades
{
    public class TarefaComentarioFacade
        (ITarefaComentarioService tarefaComentarioService,ITarefaService tarefaService,IMapper mapper) : ITarefaComentarioFacade
    {
        public async Task<long> CreateAsync(TarefaComentarioRequestDto tarefaComentarioRequestDto, CancellationToken cancellationToken)
        {
            var tarefaComentario = mapper.Map<Domain.Entities.TarefaComentario>(tarefaComentarioRequestDto);

            var tarefa = tarefaService
                            .GetById(tarefaComentario.IdTarefa, cancellationToken)
                            .Result;

            var id = await tarefaComentarioService.CreateAsync(tarefaComentario, tarefa, cancellationToken);

            return id;
        }

        public async Task<IEnumerable<TarefaComentarioResponseDto>> GetByTarefa(long idTarefa,CancellationToken cancellationToken)
        {
            var result = await tarefaComentarioService.GetByTarefa(idTarefa, cancellationToken);

            var tarefasComentarios = mapper.Map<IEnumerable<TarefaComentarioResponseDto>>(result);

            return tarefasComentarios;
        }
    }
}
