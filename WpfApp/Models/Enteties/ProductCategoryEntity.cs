using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models.Enteties
{
    public class ProductCategoryEntity
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;
        public ICollection<ProductEntity> Products { get; set; }
    }
}
