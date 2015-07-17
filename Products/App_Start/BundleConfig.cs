using System.Web.Optimization;

namespace Products
{
   public class BundleConfig
   {
      public static void RegisterBundles(BundleCollection bundles)
      {
         bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-{version}.js",
                     "~/Scripts/jquery.jeditable.js",
                     "~/Scripts/jquery-ui-1.11.4.js"
                     ));

         bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                    "~/Scripts/DataTables/jQuery.dataTables.min.js",
                    "~/Scripts/DataTables/dataTables.responsive.min.js",
                    "~/Scripts/DataTables/dataTables.bootstrap.js",
                    "~/Scripts/jquery.validate.js",
                    "~/Scripts/DataTables/jquery.dataTables.editable.js"
                    ));

         bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                     "~/Scripts/modernizr-*"));

         bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                   "~/Scripts/respond.js"));

         bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/bootstrap.min.css",
                   "~/Content/site.css",
                   "~/Content/jquery-ui.css",
                   "~/Content/DataTables/css/dataTables.jqueryui.css",
                   "~/Content/DataTables/css/dataTables.editor.min.css",
                   "~/Content/editor.jqueryui.css"));
      }
   }
}
