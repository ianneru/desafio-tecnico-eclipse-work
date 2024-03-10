using Application.Dtos;

namespace Application.Facades.Interfaces
{
    public interface IRelatorioTarefaFacade
    {
        Task<RelatorioTarefaResponseDto> GetTarefasConcluidasUltimos30Dias(UsuarioRequestDto usuario,CancellationToken cancellationToken);
    }
}
