using System.Web;
using System.Web.Optimization;

namespace Garage2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/otf").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/tomas.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/css/jquery").Include(
                    "~/Content/css/jquery/jquery.ui.autocomplete.css",
                    "~/Content/css/jquery/jquery.ui.base.css",
                    "~/Content/css/jquery/jquery-ui.css",
                    "~/Content/css/jquery/jquery.ui.accordion.css",
                    "~/Content/css/jquery/jquery.ui.all.css",
                    "~/Content/css/jquery/jquery.ui.button.css",
                    "~/Content/css/jquery/jquery.ui.core.css",
                    "~/Content/css/jquery/jquery.ui.datepicker.css",
                    "~/Content/css/jquery/jquery.ui.dialog.css",
                    "~/Content/css/jquery/jquery.ui.progressbar.css",
                    "~/Content/css/jquery/jquery.ui.resizable.css",
                    "~/Content/css/jquery/jquery.ui.selectable.css",
                    "~/Content/css/jquery/jquery.ui.slider.css",
                    "~/Content/css/jquery/jquery.ui.tabs.css",
                    "~/Content/css/jquery/jquery.ui.theme.css"));
        }
    }
}
