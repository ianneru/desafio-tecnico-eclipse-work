using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class TarefaHistoricoService(ITarefaHistoricoRepository tarefaHistoricoRepository) : ITarefaHistoricoService
    {
        public async Task<long> CreateAsync(TarefaHistorico tarefaHistorico, Tarefa? tarefa,CancellationToken cancellationToken)
        {
            if (tarefa is null)
                throw new Exceptions.ValidationException(Messages.TAREFA_NULO);

            if (tarefaHistorico is null)
                throw new Exceptions.ValidationException(Messages.HISTORICO_NULO);

            if (tarefaHistorico.IdUsuario is null)
                throw new Exceptions.ValidationException(Messages.USUARIO_NULO);


            tarefaHistorico.DataAlteracao = DateTime.Now;

            tarefaHistoricoRepository.Add(tarefaHistorico);

            await tarefaHistoricoRepository.SaveChangesAsync(cancellationToken);

            return tarefaHistorico.IdTarefaHistorico;
        }
    }
}
