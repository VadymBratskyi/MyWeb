using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB
{
    public sealed class Car
    {
        public Car()
        {
            Orders = new List<Order>();
            TypeCars = new List<TypeCar>();
        }

        public Guid Id { get; set; }
        public string CarName { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<TypeCar> TypeCars { get; set; }
    }
}