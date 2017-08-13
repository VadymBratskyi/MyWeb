using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CarShopEntity.ModelDB;

namespace CarShopEntity.DB
{
    public class Repository
    {
        public static IQueryable<TEntity> Select<TEntity>() where TEntity : class
        {
            CodeContext context = new CodeContext();

            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            return context.Set<TEntity>();
        }
       
    }
}