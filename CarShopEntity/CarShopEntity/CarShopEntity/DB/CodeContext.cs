using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CarShopEntity.ModelDB;
using CarShopEntity.ModelDB.ModelConfig;

namespace CarShopEntity.DB
{
    public class CodeContext : DbContext
    {
        public CodeContext()
            : base("CarShopDb")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new InitDb());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<ModelCar> ModelsCars { get; set; }
        public DbSet<TypeCar> TypesCars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CarConfig());
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new ModelCarConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            modelBuilder.Configurations.Add(new TypeCarConfig());
        }
    }
}