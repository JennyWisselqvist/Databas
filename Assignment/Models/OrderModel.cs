namespace Assignment.Models
{
    public class OrderModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public ICollection<Entities.ProductEntity> Products { get; set; }

    }
}
