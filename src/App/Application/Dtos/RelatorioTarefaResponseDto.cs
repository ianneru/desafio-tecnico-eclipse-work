using Domain.Enums;

namespace Application.Dtos
{
    public class RelatorioTarefaResponseDto
    {
        public RelatorioTarefaResponseDto()
        {
            Projetos = new List<ProjetoResponseDto>();
        }

        public ICollection<ProjetoResponseDto> Projetos { get; set; }
    }
}
