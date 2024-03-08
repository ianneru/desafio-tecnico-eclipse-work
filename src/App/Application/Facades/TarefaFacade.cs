using Application.Dtos;
using Application.Facades.Interfaces;
using AutoMapper;
using Domain.Services;
using Domain.Services.Interfaces;

namespace Application.Facades
{
    public class TarefaFacade(ITarefaService tarefaService, IMapper mapper) : ITarefaFacade
    {
        public async Task UpdateAsync(long id, TarefaRequestDto tarefaRequestDto, CancellationToken cancellationToken)
        {
            var tarefa = mapper.Map<Domain.Entities.Tarefa>(tarefaRequestDto);

            await tarefaService.UpdateAsync(id, tarefa, cancellationToken);
        }

        public async Task<long> CreateAsync(TarefaRequestDto tarefaRequestDto, CancellationToken cancellationToken)
        {
            var tarefa = mapper.Map<Domain.Entities.Tarefa>(tarefaRequestDto);

            var id = await tarefaService.CreateAsync(tarefa, cancellationToken);

            return id;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            await tarefaService.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<TarefaResponseDto>> GetByProjeto(long idProjeto,CancellationToken cancellationToken)
        {
            var result = await tarefaService.GetByProjeto(idProjeto,cancellationToken);

            var tarefa = mapper.Map<IEnumerable<TarefaResponseDto>>(result);

            return tarefa;
        }
    }
}
