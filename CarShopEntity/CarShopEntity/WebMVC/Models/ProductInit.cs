using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class ProductInit : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var pr1 = new Product() {Id = 1, Name = "Item_1", Price = 10, Description = "asd"};
            var pr2 = new Product() {Id = 2, Name = "Item_2", Price = 20, Description = "asd"};
            var pr3 = new Product() {Id = 3, Name = "Item_3", Price = 30, Description = "asd"};
            var pr4 = new Product() {Id = 4, Name = "Item_4", Price = 40, Description = "asd"};
            var pr5 = new Product() {Id = 5, Name = "Item_5", Price = 50, Description = "asd"};

            var cust1 = new Customer() {Id = 1, Name = "zzzz", Phone = 1423};
            var cust2 = new Customer() {Id = 1, Name = "xxxx", Phone = 4356};
            var cust3 = new Customer() {Id = 1, Name = "cccc", Phone = 5687};
            var cust4 = new Customer() {Id = 1, Name = "vvvv", Phone = 6543};
            
            var ord1 = new Orders() {Id = 1, Date = DateTime.Now, Customer = cust1, Product = pr1, IsAgree = true};
            var ord2 = new Orders() {Id = 2, Date = DateTime.Now, Customer = cust2, Product = pr2, IsAgree = true };
            var ord3 = new Orders() {Id = 3, Date = DateTime.Now, Customer = cust3, Product = pr3, IsAgree = true };
            var ord4 = new Orders() {Id = 4, Date = DateTime.Now, Customer = cust4, Product = pr4, IsAgree = true };

            context.Products.AddRange(new List<Product>() {pr1, pr2, pr3, pr5});
            context.Customers.AddRange(new List<Customer>() { cust1, cust2, cust3, cust4 });
            context.Orders.AddRange(new List<Orders>() { ord1, ord2, ord3, ord4 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}