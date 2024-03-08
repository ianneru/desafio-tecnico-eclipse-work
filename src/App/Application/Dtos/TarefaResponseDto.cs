using Domain.Enums;

namespace Application.Dtos
{
    public class TarefaResponseDto
    {
        public long Id { get; set; }

        public required string Titulo { get; set; }

        public DateTime DataVencimento { get; set; }

        public EnumStatusTarefa Status { get; set; }

        public EnumPrioridadeTarefa Prioridade { get; set; }
    }
}
