namespace Domain.Entities
{
    public class Projeto : EntityBase
    {
        public long IdProjeto { get; set; }

        public required string Titulo { get; set; }
        public virtual ICollection<Tarefa>? Tarefas { get; set; }
    }
}
