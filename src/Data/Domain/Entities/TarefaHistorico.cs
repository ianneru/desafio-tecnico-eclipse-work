using Domain.Enums;

namespace Domain.Entities
{
    public class TarefaHistorico : EntityBase
    {
        public long IdTarefaHistorico { get; set; }

        public long? IdUsuario { get; set; }

        public long? IdTarefa { get; set; }

        public string CamposAlterados { get; set; }

        public DateTime DataAlteracao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
