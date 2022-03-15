using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Models
{
    public class Customer
    {
        public int Id { get; set; } // id клиента
        public string Name { get; set; } // имя клиента
        public string Surname { get; set; } // фамилия клиента
        public string Patronomic { get; set; } // отчество клиента
        public string Address { get; set; } // адрес клиента
        public string Email { get; set; } // email клиента
        public ICollection<Sell> Sells { get; set; }
        public Customer()
        {
            Sells = new List<Sell>();
        }
    }
}
