using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestModulesLibrary
{
    public class TestModules : IHttpModule
    {
        public string _header = "Header from HTTP MODULE";
        public string _footer = "Footer from HTTP MODULE";

        private Stopwatch sw;

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            //sw = Stopwatch.StartNew();
            //HttpApplication app = (HttpApplication)sender;
            //app.Response.Write(_header);
        }

        private void context_EndRequest(object sender, EventArgs e)
        {
            //sw.Stop();
            //HttpApplication app = (HttpApplication) sender;
            //app.Response.Write(new string('-',20));
            //app.Response.Write("Time end "+ sw.Elapsed);

            //HttpApplication app = (HttpApplication)sender;
            //app.Response.Write(_footer);
        }

        private void context_Error(object sender, EventArgs e)
        {

        }

        public void Dispose()
        {
          
        }
    }
}
