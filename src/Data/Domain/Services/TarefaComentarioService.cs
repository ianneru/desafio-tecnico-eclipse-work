using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class TarefaComentarioService(ITarefaComentarioRepository tarefaComentarioRepository) : ITarefaComentarioService
    {
        public async Task<long> CreateAsync(TarefaComentario tarefaComentario, Tarefa? tarefa,CancellationToken cancellationToken)
        {
            if (tarefa is null)
                throw new Exceptions.ValidationException(Messages.TAREFA_NULO);

            if (tarefaComentario is null)
                throw new Exceptions.ValidationException(Messages.COMENTARIO_NULO);

            Validate(tarefaComentario, tarefa);

            tarefaComentario.Created = DateTime.Now;

            tarefaComentarioRepository.Add(tarefaComentario);

            await tarefaComentarioRepository.SaveChangesAsync(cancellationToken);

            return tarefa.IdTarefa;
        }

        private static void Validate(TarefaComentario tarefaComentario,Tarefa tarefa)
        {

        }

        public async Task<IEnumerable<TarefaComentario>> GetByTarefa(long idTarefa, CancellationToken cancellationToken)
        {
            var tarefasComentarios = await tarefaComentarioRepository.GetByTarefa(idTarefa, cancellationToken);

            return tarefasComentarios;
        }
    }
}
