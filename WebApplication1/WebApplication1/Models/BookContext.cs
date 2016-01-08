using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
    }
}