using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarShopEntity.Controls;
using System.Web.Caching;
using System.IO;
using CarShopEntity.Helper;
using System.Web.Security;

namespace CarShopEntity
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Request.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            
            cachePageLable.Text = DateTime.Now.ToLongTimeString();

            Person p = new Person();
            p.FirstName = "Bratskyi";
            p.LastName = "Vadym";
            p.MiddleName = "Olegovich";
            ControlObj.DataItem = p;

            tabControl.Tabs.Add("Home");
            tabControl.Tabs.Add("Services");
            tabControl.Tabs.Add("Products");
            tabControl.Tabs.Add("Contact");
            tabControl.Tabs.Add("About");

            TabsUserControl3 tab = LoadControl("~/Controls/TabsUserControl3.ascx") as TabsUserControl3;
            tab.Tabs.Add("Vados");
            tab.Tabs.Add("Romas");
            tab.Tabs.Add("Dimas");
            tab.SelectTabColor = Color.Red;
            plHolder.Controls.Add(tab);

        }

        public static string GetDate(HttpContext context)
        {
            var dt = DateTime.Now.ToLongTimeString();
            return string.Format("<h2>This is update point "+dt+ "</h2>");
        }


        protected void tabControl_OnSelectionChanged(object sender, SelectionChanchedEventArgs e)
        {
            labelTab.Text = "Select position= " + e.Position;
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            Cache["MyCache"] = "Hello Vadim";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            object ch = Cache["MyCache"];
            if (ch != null)
            {
                Lable.Text = ch.GetType() + "  "+ch.ToString();
            }
            else {
                Lable.Text = " Not Found";
            }

            object ch1 = Cache["MyFile"];
            if (ch1 != null)
            {
                Lable.Text = ch1.GetType() + "  " + ch1.ToString();
            }
            else
            {
                Lable.Text = " Not Found";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Cache.Remove("MyCache");
        }

        protected void dileBtn_Click(object sender, EventArgs e)
        {
            AddFileTOCache("TextF.txt");
            object ch = Cache["MyFile"];
            Lable.Text = ch.ToString();
        }

        private void AddFileTOCache(string fileName)
        {
            //var path = Server.MapPath(fileName);
            var path = Path.Combine(Server.MapPath("~/Content/files/"),fileName);
            StreamReader read = new StreamReader(path);
            var buff = read.ReadToEnd();
            read.Close();

            CreateAddCache(buff, path);

        }


        public void CreateAddCache(string buff, string path)
        {
            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(ReloadFile);
            CacheDependency dep = new CacheDependency(path);
            Cache.Insert("MyFile",buff, dep, 
                Cache.NoAbsoluteExpiration, 
                Cache.NoSlidingExpiration, 
                CacheItemPriority.Normal, 
                callBack);
        }

        public void ReloadFile(string key, object value, CacheItemRemovedReason reason)
        {
            if (reason == CacheItemRemovedReason.DependencyChanged)
            {
                if (key == "MyFile")
                {
                    AddFileTOCache("TextF.txt");
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("Customers<br/>");
            List<string> cust = Cachinng.Customers;
            foreach (var cu in cust)
            {
                Response.Write(cu+"<br/>");
            }
            Response.Write("<hr/>");
            
            Response.Write("Countries<br/>");

            List<string> coun = Cachinng.Countries;
            foreach (var co in coun)
            {
                Response.Write(co + "<br/>");
            }
        }
    }
}