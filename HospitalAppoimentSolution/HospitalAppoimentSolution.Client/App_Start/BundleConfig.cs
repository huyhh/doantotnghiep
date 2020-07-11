using System.Web;
using System.Web.Optimization;

namespace HospitalAppoimentSolution.Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Styles/js").Include(
                      "~/Content/js/jquery.min.js",
                      "~/Content/js/materialize.min.js",
                      "~/Content/js/owl.carousel.min.js",
                      "~/Content/js/contact-form.js",
                      "~/Content/js/fakeLoader.min.js",
                      "~/Content/js/main.js"));

            bundles.Add(new StyleBundle("~/Styles/css").Include(
                      "~/Content/css/materialize.css",
                      "~/Content/font-awesome/css/font-awesome.min.css",
                      "~/Content/css/normalize.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/owl.theme.css",
                      "~/Content/css/owl.transitions.css",
                      "~/Content/css/fakeLoader.css",
                      "~/Content/css/style.css"));
        }
    }
}
