using Domain.Entities;

namespace Application.Dtos
{
    public class ProjetoRequestDto
    {
        public required string Titulo { get; set; }

        public ICollection<TarefaResponseDto>? Tarefas { get; set; }
    }
}
