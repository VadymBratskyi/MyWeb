using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestFileHandlerLibrary
{
    class PictureViewHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<html><head><title>Picture View</title></head><body>" +
                                   GetContent(context)+
                                   "<body/><html/>");

        }


        public string GetContent(HttpContext context)
        {
            var pathFolder = context.Request.PhysicalPath.Replace("\\view.axd", string.Empty);

            List<FileInfo> files = GetAllImages(pathFolder);

            StringBuilder strBuild = new StringBuilder();

            foreach (var fileInfo in files)
            {
                strBuild.AppendFormat("<img src='{0}' alt='img' width='100px' height='100px'><br/><br/>",fileInfo.Name);
            }
         
            return strBuild.ToString();
        }


        private List<FileInfo> GetAllImages(string path)
        {
            List<FileInfo> images = new List<FileInfo>();

            List<string> extensions = new List<string>(){"*.bmp","*.jpg","*.png","*.gif"};

            DirectoryInfo dirr = new DirectoryInfo(path);

            foreach (var ex in extensions)
            {
                FileInfo[] files = dirr.GetFiles(ex);
                if (files.Length>0)
                {
                    images.AddRange(files);
                }
            }
            return images;
        }

        public bool IsReusable {
            get { return false; }
        }
    }
}
