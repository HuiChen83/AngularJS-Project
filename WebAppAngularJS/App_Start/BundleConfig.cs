using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebAppAngularJS.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // bundle scripts
            bundles.Add(new ScriptBundle("~/js").Include(
            "~/bower_components/jquery/dist/jquery.js",
            "~/bower_components/angular/angular.js",
            "~/bower_components/angular-route/angular-route.js",
            "~/Scripts/app/app.module.js",
            "~/Scripts/app/app.config.js",
            "~/Scripts/app/app.route.js",
            "~/bower_components/bootstrap/dist/js/bootstrap.js"));

            // bundle styles
            bundles.Add(new StyleBundle("~/css").Include(
            "~/bower_components/bootstrap/dist/css/bootstrap.css",
            "~/Content/Site.css"));
        }
    }
}