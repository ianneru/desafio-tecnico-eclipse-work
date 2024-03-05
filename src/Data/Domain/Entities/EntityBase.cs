namespace Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}
