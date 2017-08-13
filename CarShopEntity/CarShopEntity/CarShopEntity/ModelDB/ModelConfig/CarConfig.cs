using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB.ModelConfig
{
    public class CarConfig : EntityTypeConfiguration<Car>
    {
        public CarConfig()
        {
            HasKey(o => o.Id);
            Property(o => o.CarName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}