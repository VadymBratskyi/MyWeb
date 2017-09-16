using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShopEntity.Handler
{
    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Hellooo");
        }

        public bool IsReusable { get; }
    }
}