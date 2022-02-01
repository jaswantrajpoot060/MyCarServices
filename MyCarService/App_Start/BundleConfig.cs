using System.Web;
using System.Web.Optimization;

namespace MyCarService
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/AllfooterJs").Include(
                      "~/Scripts/jquery-3.4.1.min.js",
                       "~/Scripts/jquery.validate.min.js",
                       "~/Scripts/jquery.validate.unobtrusive.min.js",
                       "~/assetsWeb/script/jquery.js",
                       "~/assetsWeb/script/jquery-ui.js",
                       "~/assetsWeb/script/bootstrap.min.js",
                       "~/assetsWeb/script/slick.slider.min.js",
                       "~/assetsWeb/script/fancybox.pack.js",
                       "~/assetsWeb/script/isotope.min.js",
                       "~/assetsWeb/script/progressbar.js",
                       "~/assetsWeb/script/numscroller.js",
                       "~/assetsWeb/build/mediaelement-and-player.min.js",
                       "~/assetsWeb/script/functions.js"));

            bundles.Add(new StyleBundle("~/AllHeadercss").Include(
                      "~/assetsWeb/css/bootstrap.css",
                       "~/assetsWeb/css/font-awesome.css",
                       "~/assetsWeb/css/flaticon.css",
                       "~/assetsWeb/css/slick-slider.css",
                       "~/assetsWeb/css/fancybox.css",
                       "~/assetsWeb/build/mediaelementplayer.css",
                       "~/assetsWeb/style.css",
                       "~/assetsWeb/css/color.css",
                       "~/assetsWeb/css/responsive.css"));

            bundles.Add(new ScriptBundle("~/AdminLayoutJs").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/AdminLayoutcss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
