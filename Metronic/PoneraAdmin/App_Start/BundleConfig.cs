using System.Web;
using System.Web.Optimization;

namespace PoneraAdmin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/MainLayout").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/js.cookie.min.js",
                        "~/Scripts/bootstrap-hover-dropdown.js",
                        "~/Scripts/jquery.slimscroll.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/jquery.uniform.js",
                        "~/Scripts/bootstrap-switch.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/daterangepicker.js",
                        "~/Scripts/morris.js",
                        "~/Scripts/raphael-min.js",
                        "~/Scripts/fullcalendar.js",
                        "~/Scripts/app.js",
                        "~/Scripts/dashboard.js",
                        "~/Scripts/layout/layout.js",
                        "~/Scripts/layout/demo.js",
                        "~/Scripts/dashboard.js",
                        "~/Scripts/quick-sidebar.js",
                        "~/Scripts/datatables.js",
                        "~/Scripts/datatables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new StyleBundle("~/Content/MainLayout").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome/css/font-awesome.css",
                      "~/Content/simple-line-icons/simple-line-icons.css",
                      "~/Content/Themes/uniformjs/default/css/uniform.default.css",
                      "~/Content/bootstrap-switch/bootstrap3/bootstrap-switch.css",
                      "~/Content/daterangepicker-bs3.css",
                      "~/Content/morris/morris.css",
                      "~/Content/fullcalendar.css",
                      "~/Content/template/components-rounded.css",
                      "~/Content/template/plugins.css",
                      "~/Content/layout/css/layout.css",
                      "~/Content/layout/css/themes/darkblue.css",
                      "~/Content/layout/css/custom.css",
                      "~/Content/datatables/datatables.css",
                      "~/Content/datatables/datatables.bootstrap.css"));


#if (DEBUG != true)
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
