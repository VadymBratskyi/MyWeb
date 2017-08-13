using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CarShopEntity
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public string MenuItems
        {
            get
            {
                return GetMenuItems();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected virtual string GetMenuItems()
        {
            var col = new StringBuilder();

            var fileName = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"SiteMape.xml");
            var doc = XDocument.Load(fileName);

            foreach (var node in doc.Descendants("siteMapNode"))
            {
                if (node.FirstNode == null && node.LastNode == null)
                {
                    var li = string.Format("<li><a href='{0}'>{1}</a></li>", node.Attribute("url").Value,
                        node.Attribute("title").Value);
                    col.Append(li);
                }
                else
                {
                    var li = string.Format("<li class='dropdown'><a class='dropdown-toggle' data-toggle='dropdown' href='{0}'>{1}<span class='caret'></a>", node.Attribute("url").Value,
                        node.Attribute("title").Value);
                    var ul = "<ul class='dropdown-menu'>";
                    col.Append(li + ul);

                    foreach (var sub in node.Descendants("siteSubNode"))
                    {
                        var subli = string.Format("<li><a href='{0}'>{1}</a></li>", sub.Attribute("url").Value,
                            sub.Attribute("title").Value);
                        col.Append(subli);
                    }
                    col.Append("</ul>" + "</li>");
                }

            }

            return col.ToString();

        }
    }
}