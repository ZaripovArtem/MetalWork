using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Models
{
    public class Sell
    {
        public int Id { get; set; } // id продажи
        public DateTime Date { get; set; } // дата продажи
        public int Count { get; set; } // количество товара
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
