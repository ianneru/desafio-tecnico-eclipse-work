using Domain.Entities;
using Domain.Exceptions;
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
                throw new Exceptions.ValidationException("Tarefa nulo.");

            Validate(tarefa);

            tarefa.SetCreatedDate();

            tarefaRepository.Add(tarefa);

            await tarefaRepository.SaveChangesAsync(cancellationToken);

            return tarefa.Id;
        }

        private static void Validate(Tarefa tarefa)
        {
       

        }

        public async Task UpdateAsync(long id, Tarefa tarefa, CancellationToken cancellationToken)
        {
            if (id <= 0) 
                throw new Exceptions.ValidationException("Id inválido.");

            if (tarefa is null)
                throw new Exceptions.ValidationException("Tarefa nulo.");

            var entity = await tarefaRepository.GetByIdAsync(id, cancellationToken) ?? throw new EntityNotFoundException(id);

            Validate(tarefa);

            entity.SetUpdatedDate();
            entity.SetDataVencimento(tarefa.DataVencimento);
            entity.SetTitulo(tarefa.Titulo);
            entity.SetStatus(tarefa.Status);

            await tarefaRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            if (id <= 0) 
                throw new Domain.Exceptions.ValidationException("Id inválido.");

            var entity = await tarefaRepository.GetByIdAsync(id, cancellationToken) ?? throw new EntityNotFoundException(id);

            tarefaRepository.Remove(entity);

            await tarefaRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<Tarefa> GetByProjeto(long idProjeto, CancellationToken cancellationToken)
        {
            var tarefa = await tarefaRepository.GetByIdAsync(idProjeto, cancellationToken);

            return tarefa;
        }
    }
}
