﻿using System.Web;
using System.Web.Optimization;

namespace StorageCompany
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/jquery-{version}.js",
                        "~/Content/Scripts/jquery-ui.min-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Scripts/bootstrap.js",
                      "~/Content/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/Styles/bootstrap.css",
                      "~/Content/Styles/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Content/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/accordion.css",
                "~/Content/themes/base/all.css",
                "~/Content/themes/base/autocomplete.css",
                "~/Content/themes/base/base.css",
                "~/Content/themes/base/button.css",
                "~/Content/themes/base/core.css",
                "~/Content/themes/base/datepicker.css",
                "~/Content/themes/base/dialog.css",
                "~/Content/themes/base/draggable.css",
                "~/Content/themes/base/menu.css",
                "~/Content/themes/base/progressbar.css",
                "~/Content/themes/base/resizable.css",
                "~/Content/themes/base/selectable.css",
                "~/Content/themes/base/selectmenu.css",
                "~/Content/themes/base/slider.css",
                "~/Content/themes/base/sortable.css",
                "~/Content/themes/base/spinner.css",
                "~/Content/themes/base/tabs.css",                        
                "~/Content/themes/base/theme.css",
                "~/Content/themes/base/tooltip.css"));

        }
    }
}
