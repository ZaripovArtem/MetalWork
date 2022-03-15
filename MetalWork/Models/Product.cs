using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Models
{
    public class Product
    {
        public int Id { get; set; } // код изделия
        public string Name { get; set; } // название изделия
        public decimal Price { get; set; } // цена изделия
        public ICollection<ProductComposition> ProductCompositions { get; set; }
        public ICollection<Sell> Sells { get; set; }
        public Product()
        {
            ProductCompositions = new List<ProductComposition>();
            Sells = new List<Sell>();
        }
    }
}
