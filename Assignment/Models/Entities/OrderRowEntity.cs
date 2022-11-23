namespace Assignment.Models.Entities
{
    public class OrderRowEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
