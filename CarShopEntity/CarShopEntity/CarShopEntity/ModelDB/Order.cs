using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB
{
    public class Order
    {
        public Order()
        {
            Clients = new List<Client>();
        }

        public Guid Id { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public Car Car { get; set; }
        public DateTime DateTimeOrder { get; set; }
        public Decimal Price { get; set; }
    }
}