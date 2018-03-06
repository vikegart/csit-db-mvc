using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Epam.Awards.ViewHelpers
{
    public static class ViewHelpers
    {
        public static string BuildBreadcrumbNavigation(this HtmlHelper helper)
        {
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home")
            {
                return string.Empty;
            }

            StringBuilder breadcrumb = new StringBuilder("<div class=\"breadcrumb\"><li>").Append(helper.ActionLink("Menu", "Index", "Home").ToHtmlString()).Append(" / </li>");

            breadcrumb.Append("<li>");
            breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["controller"].ToString(),
                                               "Index",
                                               helper.ViewContext.RouteData.Values["controller"].ToString()));
            breadcrumb.Append(" / </li>");

            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {
                if (helper.ViewContext.RouteData.Values["id"] != null)
                {
                    breadcrumb.Append("<li>");
                    breadcrumb.Append(helper.ActionLink("id=" + helper.ViewContext.RouteData.Values["id"].ToString() + "",
                                                        helper.ViewContext.RouteData.Values["action"].ToString(),
                                                        helper.ViewContext.RouteData.Values["controller"].ToString()));
                    breadcrumb.Append(" / </li>");
                }
                else if (helper.ViewContext.RouteData.Values["name"] != null)
                {
                    breadcrumb.Append("<li>");
                    breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["name"].ToString(),
                                                        helper.ViewContext.RouteData.Values["action"].ToString(),
                                                        helper.ViewContext.RouteData.Values["controller"].ToString()));
                    breadcrumb.Append(" / </li>");
                }
                else
                {
                    breadcrumb.Append("<li>");
                    breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["action"].ToString(),
                                                        helper.ViewContext.RouteData.Values["action"].ToString(),
                                                         helper.ViewContext.RouteData.Values["controller"].ToString()));
                    breadcrumb.Append("/ </li>");
                }
            }
            return breadcrumb.Append("</div>").ToString();
        }
    }
}