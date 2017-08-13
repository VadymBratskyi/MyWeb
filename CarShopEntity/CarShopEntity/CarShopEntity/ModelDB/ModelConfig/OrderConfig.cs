using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB.ModelConfig
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            HasKey(o => o.Id);
            Property(o => o.DateTimeOrder)
                .IsRequired()
                .HasColumnType("datetime2");
            Property(o => o.Price)
                .IsRequired();
        }
    }
}