using Application.Dtos;
using Application.Facades.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;

namespace Application.Facades
{
    public class ProjetoFacade(IProjetoService projetoService, IMapper mapper) : IProjetoFacade
    {
        public async Task UpdateAsync(long id, ProjetoRequestDto projetoRequestDto, CancellationToken cancellationToken)
        {
            var projeto = mapper.Map<Domain.Entities.Projeto>(projetoRequestDto);

            await projetoService.UpdateAsync(id, projeto, cancellationToken);
        }

        public async Task<long> CreateAsync(ProjetoRequestDto projetoRequestDto, CancellationToken cancellationToken)
        {
            var projeto = mapper.Map<Domain.Entities.Projeto>(projetoRequestDto);

            var id = await projetoService.CreateAsync(projeto, cancellationToken);

            return id;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            await projetoService.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<ProjetoResponseDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await projetoService.GetAll(cancellationToken);

            var projetos = mapper.Map<IEnumerable<ProjetoResponseDto>>(result);

            return projetos;
        }
    }
}
