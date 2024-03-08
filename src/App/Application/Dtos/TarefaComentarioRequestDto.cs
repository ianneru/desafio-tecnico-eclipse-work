using Domain.Enums;

namespace Application.Dtos
{
    public class TarefaComentarioRequestDto
    {
        public required string Titulo { get; set; }

        public string Comentario { get; set; }

        public long IdTarefa { get; set; }
    }
}
