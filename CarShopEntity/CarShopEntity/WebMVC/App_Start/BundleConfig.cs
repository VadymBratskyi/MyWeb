using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundle)
        {
            bundle.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-{version}.js"));

            bundle.Add(new ScriptBundle("~/bundles/jqjs")
                .Include("~/Scripts/jquery-{version}.js", "~/Scripts/bootstrap.js"));

            bundle.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/Site.css", "~/Content/bootstrap.css", "~/Content/bootstrap-theme.css"));

        }
    }
}