using Domain.Enums;

namespace Domain.Entities
{
    public static class TarefaExtensions
    {
        public static void SetCreatedDate(this Tarefa tarefa)
        {
            tarefa.Created = DateTime.Now;
        }

        public static void SetUpdatedDate(this Tarefa tarefa)
        {
            tarefa.Updated = DateTime.Now;
        }

        public static void SetTitulo(this Tarefa tarefa,string titulo)
        {
            tarefa.Titulo = titulo;
        }

        public static void SetDataVencimento(this Tarefa tarefa,DateTime dataVencimento)
        {
            tarefa.DataVencimento = dataVencimento;
        }
        public static void SetStatus(this Tarefa tarefa, EnumStatusTarefa status)
        {
            tarefa.Status = status;
        }
    }
}
