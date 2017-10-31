using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Extention
{
    public static class HelperMethod
    {
        public static MvcHtmlString MyMessage(this HtmlHelper helper, string message)
        {
            TagBuilder tag = new TagBuilder("h3");
            tag.SetInnerText(message);
            return new MvcHtmlString(tag.ToString());
        }
    }
}