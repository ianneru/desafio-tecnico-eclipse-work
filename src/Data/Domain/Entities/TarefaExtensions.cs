using Domain.Enums;
using Domain.Exceptions;

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

        public static void ValidateProjeto(this Tarefa tarefa)
        {
            if (tarefa.IdProjeto == 0)
                throw new ValidationException("A tarefa precisa estar associado com projeto.");
        }
    }
}
