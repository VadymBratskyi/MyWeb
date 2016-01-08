using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.Controllers
{
    public class MyController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Write(requestContext.HttpContext.Request.UserHostAddress);
        }
    }
}