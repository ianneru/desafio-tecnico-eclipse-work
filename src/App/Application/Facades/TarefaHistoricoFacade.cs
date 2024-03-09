using Application.Facades.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;

namespace Application.Facades
{
    public class TarefaHistoricoFacade(IMapper mapper,ITarefaHistoricoService tarefaHistoricoService) : ITarefaHistoricoFacade
    {
        public async Task<IEnumerable<TarefaHistoricoResponseDto>> GetByTarefa(long idTarefa, CancellationToken cancellationToken)
        {
            var result = await tarefaHistoricoService.GetByTarefa(idTarefa, cancellationToken);

            var tarefasHistoricos = mapper.Map<IEnumerable<TarefaHistoricoResponseDto>>(result);

            return tarefasHistoricos;
        }
    }
}
