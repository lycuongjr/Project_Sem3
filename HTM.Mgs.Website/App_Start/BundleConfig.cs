using System.Web;
using System.Web.Optimization;

namespace HTM.Mgs.Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/Layout/Js").Include(
                        "~/Content/assets/js/jquery/jquery.min.js",
                        "~/Content/assets/js/jquery-ui/jquery-ui.min.js",
                        "~/Content/assets/js/popper.js/popper.min.js",
                        "~/Content/assets/js/bootstrap/js/bootstrap.min.js",
                        "~/Content/assets/pages/widget/excanvas.js",
                        "~/Content/assets/pages/waves/js/waves.min.js",
                        "~/Content/assets/js/jquery-slimscroll/jquery.slimscroll.js",
                        "~/Content/assets/js/modernizr/modernizr.js",
                        "~/Content/assets/js/SmoothScroll.js",
                        "~/Content/assets/js/jquery.mCustomScrollbar.concat.min.js ",
                        "~/Content/assets/js/chart.js/Chart.js",
                        "~/Content/assets/pages/widget/amchart/gauge.js",
                        "~/Content/assets/pages/widget/amchart/serial.js",
                        "~/Content/assets/pages/widget/amchart/light.js",
                        "~/Content/assets/pages/widget/amchart/pie.min.js",
                        "~/Content/assets/js/pcoded.min.js",
                        "~/Content/assets/js/vertical-layout.min.js",
                        "~/Content/assets/pages/dashboard/custom-dashboard.js",
                        "~/Content/assets/js/script.js ",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/bootstrap-input-spinner.js",
                        "~/Content/assets/plugins/toastr/toastr.min.js",
                        "~/Content/assets/plugins/datatables/jquery.dataTables.min.js",
                        "~/Content/assets/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
                        "~/Content/assets/plugins/select2/js/select2.full.js",
                        "~/Content/assets/plugins/inputmask/jquery.inputmask.bundle.js",
                        "~/Scripts/Site.js",
                        "~/Content/assets/pages/waves/js/waves.min.js"
                        ));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Layout/css").Include(
                     "~/Content/assets/images/favicon.ico",
                     "~/Content/assets/css/bootstrap/css/bootstrap.min.css",
                     "~/Content/assets/pages/waves/css/waves.min.css",
                     "~/Content/assets/icon/themify-icons/themify-icons.css",
                     "~/Content/assets/icon/font-awesome/css/font-awesome.min.css",
                     "~/Content/assets/css/jquery.mCustomScrollbar.css",
                     "~/Content/assets/css/fontawesome-free/css/all.min.css",
                     "~/Content/assets/plugins/select2/css/select2.css",
                     "~/Content/assets/plugins/select2-bootstrap4-theme/select2-bootstrap4.css",
                     "~/Content/assets/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
                     "~/Content/assets/plugins/toastr/toastr.min.css",
                     "~/Content/assets/css/style.css",
                     "~/Content/Site.css",
                     "~/Content/PagedList.css",
                     "~/Content/assets/pages/waves/css/waves.min.css"));
        }
    }
}
