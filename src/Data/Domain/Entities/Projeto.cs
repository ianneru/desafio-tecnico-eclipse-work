namespace Domain.Entities
{
    public class Projeto : EntityBase
    {
        public required ICollection<Tarefa> Tarefas { get; set; }
    }
}
