using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class ProductContext: DbContext
    {
        public ProductContext() 
            :base("ProductConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}