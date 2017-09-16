using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace TestFileHandlerLibrary
{
    public class TestFileHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string path = context.Request.PhysicalPath;

            using (FileStream flStream = new FileStream(path, FileMode.Open))
            {
                XDocument xdoc =XDocument.Load(flStream);

                var users = from user in xdoc.Descendants("User")
                    select new
                    {
                        FirstNama = user.Element("FirstName").Value,
                        LastName = user.Element("LastName").Value
                    };

                context.Response.Write("<html><head></head><body>" +
                                       "<table border='1'>" +
                                       "<tr>" +
                                       "<th>First Name<th>" +
                                       "<th>Last Name<th>" +
                                       "<tr/>");

                foreach (var us in users)
                {
                    context.Response.Write("<tr>");
                    context.Response.Write("<td>"+us.FirstNama+"<td/>");
                    context.Response.Write("<td>"+us.LastName+"<td/>");
                    context.Response.Write("<tr/>");

                }

                context.Response.Write("<table/><body/><html/>");

            }


        }

        public bool IsReusable {
            get { return false; }
        }
    }
}
