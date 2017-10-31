using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Models
{
    public class Product
    {

        public Product()
        {
            Orders = new List<Orders>();
        }

        // [HiddenInput]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        //[ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [UIHint("MultilineText")]
        public string Description { get; set; }

        [UIHint("ListTemplates")]
        public Role Role { get; set; }

        public List<Orders> Orders { get; set; }

    }

    public enum Role
    {
        Guest, User, Admin
    }
}