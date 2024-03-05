using Application.Dtos;

namespace Application.Facades.Interfaces
{
    public interface IProjetoFacade
    {
        Task<long> CreateAsync(ProjetoRequestDto projetoRequestDto, CancellationToken cancellationToken);
        Task UpdateAsync(long id, ProjetoRequestDto projetoRequestDto, CancellationToken cancellationToken);
        Task DeleteAsync(long id, CancellationToken cancellationToken);
        Task<IEnumerable<ProjetoResponseDto>> GetAll(CancellationToken cancellationToken);
    }
}
