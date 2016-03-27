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
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-confirmation.js",
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
                        "~/Scripts/datatable.js",
                        "~/Content/datatables/datatables.js",
                        "~/Content/datatables/plugins/bootstrap/datatables.bootstrap.js",
                        "~/Scripts/mustache.js",
                        "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/helpsers").Include(
                "~/Scripts/Views/namespace.js",
                "~/Scripts/Views/ajaxHelper.js",
                "~/Scripts/Views/messageHelper.js",
                "~/Scripts/Views/crudHelper.js"));

            bundles.Add(new ScriptBundle("~/bundles/responsiveTable").Include("~/Scripts/Views/responsiveTable.js"));

            bundles.Add(new ScriptBundle("~/bundles/role").Include("~/Scripts/Views/Role/role.js"));
            bundles.Add(new ScriptBundle("~/bundles/country").Include("~/Scripts/Views/Country/country.js"));
            bundles.Add(new ScriptBundle("~/bundles/user").Include("~/Scripts/Views/User/user.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include("~/Scripts/login.js"));

            bundles.Add(new StyleBundle("~/Content/MainLayout").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome/css/font-awesome.css",
                      "~/Content/simple-line-icons/simple-line-icons.css",
                      "~/Content/Themes/uniformjs/default/css/uniform.default.css",
                      "~/Content/bootstrap-switch/bootstrap3/bootstrap-switch.css",
                      "~/Content/daterangepicker-bs3.css",
                      "~/Content/morris/morris.css",
                      "~/Content/fullcalendar.css",
                      "~/Content/layout/css/layout.css",
                      "~/Content/layout/css/themes/darkblue.css",
                      "~/Content/layout/css/custom.css",
                      "~/Content/datatables/datatables.css",
                      "~/Content/template/components-rounded.css",
                      "~/Content/template/plugins.css",
                      //"~/Content/datatables/plugins/bootstrap/datatables.bootstrap.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                "~/Content/login.css"));


#if (DEBUG != true)
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
