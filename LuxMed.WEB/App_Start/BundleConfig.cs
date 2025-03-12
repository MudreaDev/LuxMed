using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LuxMed.WEB.App_Start
{
	public static class BundleConfig
	{
		public static void RegisterBundle(BundleCollection bundles)
		{
            //Main css
            //href = "css/style.css" rel = "stylesheet
            // Main CSS
            bundles.Add(new StyleBundle("~/bundles/main/css")
                .Include("~/Content/css/style.css", new CssRewriteUrlTransform()));

            // Bootstrap CSS
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            // OwlCarousel CSS
            bundles.Add(new StyleBundle("~/bundles/owlcarousel/css")
                .Include("~/Content/lib/owlcarousel/assets/owl.carousel.min.css", new CssRewriteUrlTransform()));

            // Main JS
            bundles.Add(new ScriptBundle("~/bundles/main/js")
                .Include("~/Content/js/main.js"));

            // Chart JS
            bundles.Add(new ScriptBundle("~/bundles/chart/js")
                .Include("~/lib/chart/chart.min.js"));

            // Easing JS
            bundles.Add(new ScriptBundle("~/bundles/easing/js")
                .Include("~/lib/easing/easing.min.js"));

            // Waypoints JS
            bundles.Add(new ScriptBundle("~/bundles/waypoints/js")
                .Include("~/lib/waypoints/waypoints.min.js"));

            // OwlCarousel JS
            bundles.Add(new ScriptBundle("~/bundles/owlcarousel/js")
                .Include("~/lib/owlcarousel/owl.carousel.min.js"));

            // Tempus Dominus JS (Date/Time Picker)
            bundles.Add(new ScriptBundle("~/bundles/tempus/js")
                .Include(
                    "~/lib/tempusdominus/js/moment.min.js",
                    "~/lib/tempusdominus/js/moment-timezone.min.js",
                    "~/lib/tempusdominus/js/tempusdominus-bootstrap-4.js"
                ));

            // Activează minificarea și concatenarea în Release Mode
            BundleTable.EnableOptimizations = true;


        }
    }
}