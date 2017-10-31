using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMVC.App_Start;
using WebMVC.Models;

namespace WebMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new ProductInit());

            AreaRegistration.RegisterAllAreas();

            BundleConfig.RegisterBundle(BundleTable.Bundles);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
