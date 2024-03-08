using Domain.Enums;

namespace Application.Dtos
{
    public class TarefaComentarioResponseDto
    {
        public required string Titulo { get; set; }

        public string Comentario { get; set; }

        public DateTime Created { get; set; }
    }
}
