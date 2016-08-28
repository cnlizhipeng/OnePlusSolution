using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace OP.MvcView
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }

        public void Application_Error()
        {
            var statusCode = Context.Response.StatusCode;
            var routingData = Context.Request.RequestContext.RouteData;
            if (statusCode == 404 || statusCode == 500)
            {
                Response.Clear();
                //var area = DataHelper.ConvertTo(routingData.DataTokens["area"], string.Empty);
                //if (area == "Admin")
                //{
                //    Response.RedirectToRoute("Admin_Default", new { controller = "BackError", action = "NotFound", IsReload = 1 });
                //}
                //else
                //{
                Response.RedirectToRoute("Default", new { controller = "Error", action = "Index", id = UrlParameter.Optional });
                //}

            }
        }

        protected void Application_EndRequest()
        {
            
        }
    }
}
