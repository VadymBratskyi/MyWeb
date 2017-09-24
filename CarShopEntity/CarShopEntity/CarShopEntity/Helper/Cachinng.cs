using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;


namespace CarShopEntity.Helper
{
    public class Field
    {
        public static readonly string customer = "customer";
        public static readonly string countries = "countries";
    }


    public class Cachinng
    {
        public static List<string> Customers
        {
            get
            {
                object data = HttpContext.Current.Cache[Field.customer];
                if (data == null)
                {
                    data = LoadCustomer();
                    HttpContext.Current.Cache[Field.customer] = data;
                }
                return (List<string>)data;
            }          
        }

        public static List<string> Countries
        {
            get
            {
                object data = HttpContext.Current.Cache[Field.countries];
                if (data == null)
                {
                    data = LoadCountries();
                    HttpContext.Current.Cache[Field.countries] = data;
                }
                return (List<string>)data;
            }
        }



        public static List<string> LoadCustomer()
        {
            Thread.Sleep(5000);
            var datas = new List<string>() {"Asus","Mobile","Amazon","Google" };
            return datas;
        }

        public static List<string> LoadCountries()
        {
            Thread.Sleep(5000);
            var datas = new List<string>() { "UK", "USA", "Ukrain", "German" };
            return datas;
        }
    }
}