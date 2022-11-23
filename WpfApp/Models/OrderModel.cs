using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models.Enteties;

namespace WpfApp.Models
{
    internal class OrderModel
    {
        public int CustomerId { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

    }
}
