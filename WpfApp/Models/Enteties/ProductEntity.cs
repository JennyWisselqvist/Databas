﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models.Enteties
{
     public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ProductCategoryEntity Category { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}
