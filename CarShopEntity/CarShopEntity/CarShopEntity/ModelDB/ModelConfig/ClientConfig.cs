using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB.ModelConfig
{
    public class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            HasKey(o => o.Id);
            Property(o => o.FullName)
                .IsRequired()
                .HasMaxLength(50);
            Property(o => o.Birthday)
                .IsOptional()
                .HasColumnType("datetime2");
            Property(o => o.Phone).IsOptional();
        }
    }
}