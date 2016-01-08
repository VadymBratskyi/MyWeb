using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication1.Util
{
    public class HtmlResult: ActionResult
    {
        private string MyHtml;

        public HtmlResult(string html)
        {
           MyHtml = html;
        }
        
        public override void ExecuteResult(ControllerContext context)
        {
            var fullHtml = "<!DOCTYPE html><html><head>" +
                              "<title>Main pages" +
                              "</title>" +
                              "</head>" +
                              "<body>" +
                              MyHtml+
                              "</body>"+
                              "</html>";
            context.HttpContext.Response.Write(fullHtml);
        }
    }
}