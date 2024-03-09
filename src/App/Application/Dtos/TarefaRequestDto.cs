using Domain.Enums;

namespace Application.Dtos
{
    public class TarefaRequestDto
    {
        public EnumPrioridadeTarefa Prioridade { get; set; }
        
        public required string Titulo { get; set; }

        public DateTime DataVencimento { get; set; }

        public long IdProjeto { get; set; }

        public UsuarioRequestDto Usuario { get; set; }
    }
}
