using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services
{
    public class TarefaService(ITarefaRepository tarefaRepository) : ITarefaService
    {
        public async Task<long> CreateAsync(Tarefa tarefa, Projeto? projeto,CancellationToken cancellationToken)
        {
            if (tarefa is null)
                throw new Exceptions.ValidationException(Messages.TAREFA_NULO);

            if (projeto is null)
                throw new Exceptions.ValidationException(Messages.PROJETO_NULO);

            Validate(tarefa,projeto);

            tarefa.SetCreatedDate();

            tarefaRepository.Add(tarefa);

            await tarefaRepository.SaveChangesAsync(cancellationToken);

            return tarefa.IdTarefa;
        }

        private static void Validate(Tarefa tarefa,Projeto projeto)
        {
            tarefa.ValidateProjeto();

            if((projeto.Tarefas ?? []).Any() && projeto.Tarefas.Count > 20)
                throw new Domain.Exceptions.ValidationException(Messages.TAREFAS_PROJETO_20);
        }

        public async Task UpdateAsync(long id, Tarefa tarefa,Projeto? projeto, CancellationToken cancellationToken)
        {
            if (id <= 0) 
                throw new Exceptions.ValidationException(Messages.ID_INVALIDO);

            if (tarefa is null)
                throw new Exceptions.ValidationException(Messages.TAREFA_NULO);

            if (projeto is null)
                throw new Exceptions.ValidationException(Messages.PROJETO_NULO);

            var entity = await tarefaRepository.GetByIdAsync(id, cancellationToken) ?? throw new EntityNotFoundException(id);

            Validate(tarefa,projeto);

            entity.SetUpdatedDate();
            entity.SetDataVencimento(tarefa.DataVencimento);
            entity.SetTitulo(tarefa.Titulo);
            entity.SetStatus(tarefa.Status);

            await tarefaRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            if (id <= 0) 
                throw new Domain.Exceptions.ValidationException(Messages.ID_INVALIDO);

            var entity = await tarefaRepository.GetByIdAsync(id, cancellationToken) ?? throw new EntityNotFoundException(id);

            tarefaRepository.Remove(entity);

            await tarefaRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Tarefa>> GetByProjeto(long idProjeto, CancellationToken cancellationToken)
        {
            var tarefas = await tarefaRepository.GetByProjeto(idProjeto, cancellationToken);

            return tarefas;
        }

        public async Task<Tarefa> GetById(long id, CancellationToken cancellationToken)
        {
            return await tarefaRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
