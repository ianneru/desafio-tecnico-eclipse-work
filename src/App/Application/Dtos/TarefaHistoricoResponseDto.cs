using Application.Dtos;
using Domain.Enums;

namespace Domain.Entities
{
    public class TarefaHistoricoResponseDto : EntityBase
    {
        public UsuarioRequestDto Usuario { get; set; }

        public string CamposAlterados { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
