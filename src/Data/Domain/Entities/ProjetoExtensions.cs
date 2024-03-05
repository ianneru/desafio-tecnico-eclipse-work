namespace Domain.Entities
{
    public static class ProjetoExtensions
    {
        public static void SetCreatedDate(this Projeto projeto)
        {
            projeto.Created = DateTime.Now;
        }
    }
}
