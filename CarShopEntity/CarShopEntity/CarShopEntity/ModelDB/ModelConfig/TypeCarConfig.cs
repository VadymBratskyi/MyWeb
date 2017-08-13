using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CarShopEntity.ModelDB.ModelConfig
{
    public class TypeCarConfig : EntityTypeConfiguration<TypeCar>
    {
        public TypeCarConfig()
        {
            HasKey(o => o.Id);
            Property(o => o.TypeName)
                .IsRequired();
        }
    }
}