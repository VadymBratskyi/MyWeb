using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Extention
{
    public static class HelperMethod
    {
        private static ProductContext db = new ProductContext();

        public static MvcHtmlString MyMessage(this HtmlHelper helper, string message)
        {
            TagBuilder tag = new TagBuilder("h3");
            tag.SetInnerText(message);
            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString GetCustomers(this HtmlHelper helper, Orders cust)
        {
            TagBuilder select = new TagBuilder("select");
            select.MergeAttribute("name","id");
            TagBuilder optionAll = new TagBuilder("option");
            optionAll.MergeAttribute("value", "0");
            optionAll.InnerHtml = "All";
            select.InnerHtml += optionAll;
            foreach (var customer in db.Customers)
            {
                TagBuilder option = new TagBuilder("option");
                option.MergeAttribute("value", customer.Id.ToString());
                if (cust!=null && customer.Id == cust.CustomerId)
                {
                    option.MergeAttribute("selected", "selected");
                }
                option.InnerHtml = customer.Name;
                select.InnerHtml += option.ToString();
            }
            return new MvcHtmlString(select.ToString());
        }
    }
}