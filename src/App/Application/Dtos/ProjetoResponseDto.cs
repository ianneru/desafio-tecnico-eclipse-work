namespace Application.Dtos
{
    public class ProjetoResponseDto
    {
        public long IdProjeto { get; set; }    
        public required string Titulo { get; set; }

        public ICollection<TarefaResponseDto>? Tarefas { get; set; }
    }
}
