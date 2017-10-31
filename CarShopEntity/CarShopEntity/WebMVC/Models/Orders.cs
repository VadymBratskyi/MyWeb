using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.Extention;

namespace WebMVC.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        [MyValid(ErrorMessage = "Error")]
        public bool IsAgree { get; set; }
    }
}