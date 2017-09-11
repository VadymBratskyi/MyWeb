using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB
{
    public partial class ModelCar
    {
        public Guid Id { get; set; }
        public double PositionIndex { get; set; }
        public string ModelName { get; set; }
        public Guid? CarId { get; set; }
        public Car Car { get; set; }
        public Guid? TypeCarId { get; set; }
        public TypeCar TypeCar { get; set; }
        public string ImgPath { get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public DateTime IssueDate { get; set; }
        public string Fuel { get; set; }
        public decimal Price { get; set; }
    }
}