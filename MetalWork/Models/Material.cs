using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Models
{
    public class Material
    {
        public int Id { get; set; } // id материала
        public string Name { get; set; } // название материала
        public decimal Price { get; set; } // цена материала
        public ICollection<ProductComposition> ProductCompositions { get; set; }
        public Material()
        {
            ProductCompositions = new List<ProductComposition>();
        }
    }
}
