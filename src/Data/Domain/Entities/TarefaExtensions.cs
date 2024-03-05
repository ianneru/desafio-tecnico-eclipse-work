namespace Domain.Entities
{
    public static class TarefaExtensions
    {
        public static void SetCreatedDate(this Tarefa tarefa)
        {
            tarefa.Created = DateTime.Now;
        }
    }
}
