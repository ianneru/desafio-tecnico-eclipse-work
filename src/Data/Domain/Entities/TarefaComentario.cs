using Domain.Enums;

namespace Domain.Entities
{
    public class TarefaComentario : EntityBase
    {
        public long IdTarefaComentario { get; set; }

        public required string Titulo { get; set; }
        
        public string Comentario { get; set; }

        public long IdTarefa { get; set; }

        public virtual Tarefa Tarefa { get; set; }
    }
}
