using Application.Dtos;
using Application.Facades.Interfaces;
using AutoMapper;
using Domain.Services.Interfaces;

namespace Application.Facades
{
    public class TarefaFacade
        (ITarefaService tarefaService, IProjetoService projetoService, IMapper mapper,
        ITarefaHistoricoService tarefaHistoricoService,
        IUsuarioService usuarioService) : ITarefaFacade
    {
        public async Task UpdateAsync(long id, TarefaRequestDto tarefaRequestDto, CancellationToken cancellationToken)
        {
            var tarefa = mapper.Map<Domain.Entities.Tarefa>(tarefaRequestDto);

            var projeto = projetoService
                            .GetAll(cancellationToken)
                            .Result
                            .FirstOrDefault(o => o.IdProjeto == tarefa.IdProjeto);

            var changes = await tarefaService.UpdateAsync(id, tarefa, projeto, cancellationToken);

            var usuario = await usuarioService.GetByNome(tarefaRequestDto.Usuario?.Nome, cancellationToken);

            await tarefaHistoricoService.CreateAsync(
                new Domain.Entities.TarefaHistorico
                {
                    IdUsuario = usuario?.IdUsuario,
                    IdTarefa = id,
                    Created = DateTime.Now,
                    CamposAlterados = string.Join(", ",
                        changes.Select(x => "['" + x.Item1 + "','" + x.Item2 + "']"))
                },
                tarefa, cancellationToken);
        }

        public async Task<long> CreateAsync(TarefaRequestDto tarefaRequestDto, CancellationToken cancellationToken)
        {
            var tarefa = mapper.Map<Domain.Entities.Tarefa>(tarefaRequestDto);

            var projeto = projetoService
                            .GetAll(cancellationToken)
                            .Result
                            .FirstOrDefault(o => o.IdProjeto == tarefa.IdProjeto);

            var usuario = await usuarioService.GetByNome(tarefaRequestDto.Usuario?.Nome,cancellationToken);

            var id = await tarefaService.CreateAsync(tarefa, projeto, cancellationToken);

            tarefa.IdTarefa = id;

            if (id > 0)
                await tarefaHistoricoService.CreateAsync(
                    new Domain.Entities.TarefaHistorico
                    {
                        IdUsuario = usuario?.IdUsuario,
                        IdTarefa = id,
                        Created = DateTime.Now,
                        CamposAlterados = "Tarefa criada"
                    },
                    tarefa, cancellationToken);

            return id;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            await tarefaService.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<TarefaResponseDto>> GetByProjeto(long idProjeto, CancellationToken cancellationToken)
        {
            var result = await tarefaService.GetByProjeto(idProjeto, cancellationToken);

            var tarefa = mapper.Map<IEnumerable<TarefaResponseDto>>(result);

            return tarefa;
        }
    }
}
