using System.Web;
using System.Web.Optimization;

namespace LMS
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/notify.min.js",
                      "~/Scripts/respond.js",
                      "~/Content/LMSCustom/Site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryModal").Include(
                "~/Content/JQryModal/js/jquery-latest.min.js",
                "~/Content/JQryModal/js/jquery.modal.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/w3.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryModal").Include(
                      "~/Content//JQryModal/css/jquery.modal.css",
                      "~/Content//JQryModal/css/jquery.modal.theme-atlant.css",
                      "~/Content//JQryModal/css/jquery.modal.theme-xenon.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/DataTables/css").Include(
                "~/Content/DataTables/css/jquery.dataTables.min.css",
                "~/Content/DataTables/css/dataTables.bootstrap4.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.min.js"
                ));
        }
    }
}