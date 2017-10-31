using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShopEntity
{
    public partial class AsyncPage : System.Web.UI.Page
    {
        private WebRequest _request = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Trace.Write("Thread= "+Thread.CurrentThread.ManagedThreadId, "->Page_Load");

          
           // PageAsyncTask task = new PageAsyncTask(OnBegin, OnEnd, OnTimeOut, null);
            PageAsyncTask task = new PageAsyncTask(GetTask);
            RegisterAsyncTask(task);

            Trace.Write("Thread= " + Thread.CurrentThread.ManagedThreadId, "->Page_Load end");

        }

        private async Task GetTask()
        {
            Trace.Write("Thread= " + Thread.CurrentThread.ManagedThreadId, "->GetTask");

            await Task.Delay(3000);
            output.Text += "<br/>Hello from Thred " + Thread.CurrentThread.ManagedThreadId;
        }


        private void OnTimeOut(IAsyncResult ar)
        {
            output.Text = "TimeOut!!!";
        }

        private void OnEnd(IAsyncResult ar)
        {
            string txt;

            using (WebResponse reaponse = _request.EndGetResponse(ar))
            {
                using (StreamReader reader = new StreamReader(reaponse.GetResponseStream()))
                {
                    txt = reader.ReadToEnd();
                }
            }

            Regex reg = new Regex("href=\"(\\S*)\"");
            MatchCollection coll = reg.Matches(txt);

            StringBuilder bld = new StringBuilder();
            foreach (Match match in coll)
            {
                bld.Append(match.Groups[1] + "<br/>");
            }

            output.Text = bld.ToString();

            Trace.Write("Thread= "+Thread.CurrentThread.ManagedThreadId, "->OnEnd");

        }

        private IAsyncResult OnBegin(object sender, EventArgs eventArgs, AsyncCallback cb, object extraData)
        {
            Trace.Write("Thread= " + Thread.CurrentThread.ManagedThreadId, "->OnBegin");
            _request = WebRequest.Create("http://msdn.microsoft.com");
            return _request.BeginGetResponse(cb, extraData);
        }
        
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Trace.Write("Thread= " + Thread.CurrentThread.ManagedThreadId, "->Page_PreRenderComplete");
           
        }
    }
}