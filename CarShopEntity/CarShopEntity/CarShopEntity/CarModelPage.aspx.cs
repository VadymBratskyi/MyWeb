using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace CarShopEntity
{
    public partial class CarModelPage : System.Web.UI.Page
    {
        private WebRequest _request = null; 

        protected void Page_Load(object sender, EventArgs e)
        {
          AddOnPreRenderCompleteAsync(new BeginEventHandler(BeginAsyncOperation), new EndEventHandler(EndAsyncOperation));

          Trace.Write("Thread= "+Thread.CurrentThread.ManagedThreadId, " AddOnPreRenderCompleteAsync");

        }

        private IAsyncResult BeginAsyncOperation(object sender, EventArgs eventArgs, AsyncCallback cb, object extraData)
        {
            Trace.Write("Thread= "+Thread.CurrentThread.ManagedThreadId, " BeginAsyncOperation");

            _request = WebRequest.Create("http://msdn.microsoft.com");
            return _request.BeginGetResponse(cb, null);
        }

        private void EndAsyncOperation(IAsyncResult ar)
        {
            string txt;
            using (WebResponse resp = _request.EndGetResponse(ar))
            {
                Stream stream = resp.GetResponseStream();
                using (StreamReader read = new StreamReader(stream))
                {
                    txt = read.ReadToEnd();
                }
            }

            Regex reg = new Regex("href=\"(\\S*)\"");
            MatchCollection coll = reg.Matches(txt);

            StringBuilder bld = new StringBuilder();
            foreach (Match match in coll)
            {
                bld.Append(match.Groups[1]+"<br/>");
            }

            Output.Text +=bld.ToString();

            Trace.Write("Thread= "+Thread.CurrentThread.ManagedThreadId, " EndAsyncOperation");

        }

        protected void Page_PreRenderComplete(EventArgs e)
        {
            Trace.Write("Thread= "+Thread.CurrentThread.ManagedThreadId, " Page_PreRenderComplete");
        }
    }

}