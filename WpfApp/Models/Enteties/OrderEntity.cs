using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models.Enteties
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(30);
        public int CustomerId { get; set; }

        public OrderEntity Customer { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }
}
