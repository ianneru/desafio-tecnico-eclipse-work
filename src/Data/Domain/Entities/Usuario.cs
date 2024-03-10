using Domain.Enums;

namespace Domain.Entities
{
    public class Usuario
    {
        public long IdUsuario { get; set; }

        public required string Nome { get; set; }

        public EnumFuncao Funcao { get; set; }

        public virtual TarefaHistorico TarefaHistorico { get; set;}
    }
}
