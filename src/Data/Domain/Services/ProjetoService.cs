using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Services
{
    public class ProjetoService(IProjetoRepository projetoRepository) : IProjetoService
    {
        public async Task<long> CreateAsync(Projeto projeto, CancellationToken cancellationToken)
        {
            if (projeto is null)
                throw new Domain.Exceptions.ValidationException(Messages.PROJETO_NULO);

            Validate(projeto);

            projeto.SetCreatedDate();

            projetoRepository.Add(projeto);
            await projetoRepository.SaveChangesAsync(cancellationToken);

            return projeto.IdProjeto;
        }

        private static void Validate(Projeto projeto)
        {
       

        }

        public Task UpdateAsync(long id, Projeto projeto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                throw new Domain.Exceptions.ValidationException(Messages.ID_INVALIDO);

            var entity = await projetoRepository.GetByIdAsync(id, cancellationToken) ?? throw new EntityNotFoundException(id);

            if (entity.Tarefas.Any())
                throw new Domain.Exceptions.ValidationException(Messages.EXCLUIR_PROJETO);

            projetoRepository.Remove(entity);

            await projetoRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Projeto>> GetAll(CancellationToken cancellationToken)
        {
            var projetos = await projetoRepository.GetAllAsync(cancellationToken);

            return projetos;
        }
    }
}
