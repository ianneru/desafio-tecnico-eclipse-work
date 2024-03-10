using Application.Dtos;
using Application.Facades.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;

namespace Application.Facades
{
    public class RelatorioTarefaFacade
        (ITarefaService tarefaService, 
        IProjetoService projetoService,
        IMapper mapper,
        IUsuarioService usuarioService) : IRelatorioTarefaFacade
    {
        public async Task<RelatorioTarefaResponseDto> GetTarefasConcluidasUltimos30Dias(UsuarioRequestDto usuario, CancellationToken cancellationToken)
        {
            if (usuario is null)
                throw new Domain.Exceptions.ValidationException("Usuário nulo");

            var usuarioDB = await usuarioService.GetByNome(usuario.Nome,cancellationToken);

            if (usuarioDB is null || usuarioDB.Funcao != Domain.Enums.EnumFuncao.Gerente)
                throw new Domain.Exceptions.ValidationException("Gerente necessário para acessar os relatórios de tarefas");

            var projetos = await projetoService.GetAll(cancellationToken);

            var retorno = new RelatorioTarefaResponseDto();

            foreach(var projeto in projetos)
            {
                retorno.Projetos.Add(mapper.Map<ProjetoResponseDto>(projeto));

                var tarefasConcluidas = tarefaService.GetByProjeto(projeto.IdProjeto, cancellationToken)
                                                        .Result
                                                        .Where(o => o.Status == Domain.Enums.EnumStatusTarefa.Concluida && o.Updated > DateTime.Now.AddDays(-30))
                                                        .ToList();


                var ultimoProjeto = retorno.Projetos.Last();

                foreach(var tarefaConcluida in tarefasConcluidas)
                    ultimoProjeto.Tarefas.Add(mapper.Map<TarefaResponseDto>(tarefaConcluida));
            }

            return retorno;
        }
    }
}
