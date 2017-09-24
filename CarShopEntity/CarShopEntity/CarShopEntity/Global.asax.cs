using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Newtonsoft.Json;
using Configuration = CarShopEntity.Migrations.Configuration;

namespace CarShopEntity
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRouter(RouteTable.Routes);
        }
        private void RegisterRouter(RouteCollection routes)
        {
            routes.MapPageRoute("Homepage", "Home", "~/HomePage.aspx");
            routes.MapPageRoute("Carpage", "Cars", "~/CarsPage.aspx");
            routes.MapPageRoute("Modelpage", "Models", "~/CarModelPage.aspx");
            routes.MapPageRoute("Typepage", "Types", "~/TypeCarsPage.aspx");
            routes.MapPageRoute("Clientpage", "Clients", "~/ClientsPage.aspx");
            routes.MapPageRoute("Orderpage", "Orders", "~/OrdersPage.aspx");
            routes.MapPageRoute("Userpage", "User", "~/MemberShipApy.aspx");
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "device")
            {
                return context.Request.Browser.Type;
            }
            else
            {
                return null;
            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError().InnerException;
            var exx = Server.GetLastError().GetBaseException().Message;
            Response.Redirect("ErrorPage.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}