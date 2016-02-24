using System.Web;
using System.Web.Optimization;

namespace FoodTracker2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-1.9.1.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Css").Include(
            "~/Content/bootstrap.css",
            "~/Content/Site.css"));
        }
    }
}
