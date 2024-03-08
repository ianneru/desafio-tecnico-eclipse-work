namespace Domain.Entities
{
    public class Projeto : EntityBase
    {
        public required string Titulo { get; set; }
        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}
