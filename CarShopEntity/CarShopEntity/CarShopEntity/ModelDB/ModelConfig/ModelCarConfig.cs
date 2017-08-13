using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB.ModelConfig
{
    public class ModelCarConfig : EntityTypeConfiguration<ModelCar>
    {
        public ModelCarConfig()
        {
            HasKey(o => o.Id);
            Property(o => o.ModelName)
                .IsRequired()
                .HasMaxLength(50);
            Property(o => o.IssueDate)
                .IsRequired()
                .HasColumnType("datetime2");
        }
    }
}