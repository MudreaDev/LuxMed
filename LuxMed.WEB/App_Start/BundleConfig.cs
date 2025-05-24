using System.Web.Optimization;

namespace LuxMed.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {


            // Bootstrap style
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/css/animate.css",
                      "~/Content/css/aos.css",
                      "~/Content/css/app.css",
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/flaticon.css",
                      "~/Content/css/icomoon.css",
                      "~/Content/css/icons.css",
                      "~/Content/css/ionicons.min.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/open-iconic-bootstrap.min.css",
                      "~/Content/css/owl.carousel.min.css",
                      "~/Content/css/owl.theme.default.min.css",
                      "~/Content/css/style.css"
                      ));

            // Bootstrap js
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                       "~/Content/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Content/js/jquery.min.js",
                      "~/Content/js/jquery-migrate-3.0.1.min.js",
                      "~/Content/js/jquery.easing.1.3.js",
                      "~/Content/js/jquery.waypoints.min.js",
                      "~/Content/js/jquery.stellar.min.js",
                      "~/Content/js/jquery.magnific-popup.min.js",
                      "~/Content/js/jquery.animateNumber.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Content/js/popper.min.js",
                      "~/Content/js/owl.carousel.min.js",
                      "~/Content/js/aos.js",
                      "~/Content/js/scrollax.min.js",
                      "~/Content/js/google-map.js",
                      "~/Content/js/main.js"
                      ));


        }
    }
}