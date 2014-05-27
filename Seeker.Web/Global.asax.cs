using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Seeker.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Routes.Add(
                "default", 
                new HttpRoute("{controller}"));

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}