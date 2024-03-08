using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services
{
    public class TarefaService(ITarefaRepository tarefaRepository) : ITarefaService
    {
        private const string TAREFA_NULO = "Tarefa nulo.";
        private const string PROJETO_NULO = "Projeto nulo.";
        private const string ID_INVALIDO = "Tarefa nulo.";
        private const string TAREFAS_PROJETO_20 = "Um projeto não pode conter mais que 20 tarefas.";

        public async Task<long> CreateAsync(Tarefa tarefa, Projeto? projeto,CancellationToken cancellationToken)
        {
            if (tarefa is null)
                throw new Exceptions.ValidationException(TAREFA_NULO);

            if (projeto is null)
                throw new Exceptions.ValidationException(PROJETO_NULO);

            Validate(tarefa,projeto);

            tarefa.SetCreatedDate();

            tarefaRepository.Add(tarefa);

            await tarefaRepository.SaveChangesAsync(cancellationToken);

            return tarefa.IdTarefa;
        }

        private static void Validate(Tarefa tarefa,Projeto projeto)
        {
            tarefa.ValidateProjeto();

            if(projeto.Tarefas.Any() && projeto.Tarefas.Count > 20)
                throw new Domain.Exceptions.ValidationException(TAREFAS_PROJETO_20);
        }

        public async Task UpdateAsync(long id, Tarefa tarefa,Projeto? projeto, CancellationToken cancellationToken)
        {
            if (id <= 0) 
                throw new Exceptions.ValidationException(ID_INVALIDO);

            if (tarefa is null)
                throw new Exceptions.ValidationException(TAREFA_NULO);

            if (projeto is null)
                throw new Exceptions.ValidationException(PROJETO_NULO);

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
                throw new Domain.Exceptions.ValidationException(ID_INVALIDO);

            var entity = await tarefaRepository.GetByIdAsync(id, cancellationToken) ?? throw new EntityNotFoundException(id);

            tarefaRepository.Remove(entity);

            await tarefaRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Tarefa>> GetByProjeto(long idProjeto, CancellationToken cancellationToken)
        {
            var tarefas = await tarefaRepository.GetByProjeto(idProjeto, cancellationToken);

            return tarefas;
        }
    }
}
