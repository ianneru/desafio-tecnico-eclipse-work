using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services
{
    public class TarefaService(ITarefaRepository tarefaRepository) : ITarefaService
    {
        public async Task<long> CreateAsync(Tarefa tarefa, CancellationToken cancellationToken)
        {
            if (tarefa is null)
                throw new ValidationException("Tarefa nulo.");

            Validate(tarefa);

            tarefa.SetCreatedDate();

            tarefaRepository.Add(tarefa);
            await tarefaRepository.SaveChangesAsync(cancellationToken);

            return tarefa.Id;
        }

        private static void Validate(Tarefa tarefa)
        {
       

        }

        public Task UpdateAsync(long id, Tarefa tarefa, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
