using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB
{
    public class Client
    {
        public Client()
        {
            Orders = new List<Order>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public int Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}