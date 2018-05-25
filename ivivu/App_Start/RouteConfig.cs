using System.Web.Mvc;
using System.Web.Routing;

namespace ivivu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
          
            routes.MapRoute(
                name: "Default",
				url: "{controller}/{action}/{id1}/{id2}/{id3}",
				defaults: new {
				    controller = "Home",
				    action = "index",
				    id1 = UrlParameter.Optional,
				    id2 = UrlParameter.Optional,
				    id3 = UrlParameter.Optional
			    }
            );
        }
    }
}
