using Domain.Enums;

namespace Domain.Entities
{
    public class Tarefa : EntityBase
    {
        public long IdTarefa { get; set; }
        public required string Titulo { get; set; }
        
        public DateTime DataVencimento { get; set; }

        public EnumStatusTarefa Status { get; set; }

        public EnumPrioridadeTarefa Prioridade { get; set; }

        public long IdProjeto { get; set; }

        public virtual Projeto Projeto { get; set; }

        public virtual ICollection<TarefaComentario>? TarefaComentarios { get; set; }
    }
}
