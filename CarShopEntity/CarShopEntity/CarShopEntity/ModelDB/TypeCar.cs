using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB
{
    public sealed class TypeCar
    {
        public TypeCar()
        {
            Cars = new List<Car>();
            ModelCars = new List<ModelCar>();
        }

        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<ModelCar> ModelCars { get; set; }
    }
}