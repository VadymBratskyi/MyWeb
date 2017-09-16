using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShopEntity.Handler
{
    /// <summary>
    /// Summary description for ImgHandler
    /// </summary>
    public class ImgHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpg";
            var path = context.Server.MapPath("~/ImageSource/5.jpg");
            context.Response.WriteFile(path);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}