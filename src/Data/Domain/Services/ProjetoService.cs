using Domain.Entities;
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
                throw new ValidationException("Projeto nulo.");

            Validate(projeto);

            projeto.SetCreatedDate();

            projetoRepository.Add(projeto);
            await projetoRepository.SaveChangesAsync(cancellationToken);

            return projeto.Id;
        }

        private static void Validate(Projeto projeto)
        {
       

        }

        public Task UpdateAsync(long id, Projeto projeto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Projeto>> GetAll(CancellationToken cancellationToken)
        {
            var projetos = await projetoRepository.GetAllAsync(cancellationToken);

            return projetos;
        }
    }
}
