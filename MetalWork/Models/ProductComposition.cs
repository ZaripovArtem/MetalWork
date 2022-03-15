using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Models
{
    public class ProductComposition
    {
        public int Id { get; set; } // id связки продукт-материал
        public int ProductId { get; set; } // id продукта
        public int MaterialId { get; set; } // id материала
        public int Count { get; set; } // количество материала
        public Product Product { get; set; }
        public Material Material { get; set; }

    }
}
