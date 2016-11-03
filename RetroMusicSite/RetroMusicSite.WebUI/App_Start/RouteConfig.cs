using System.Web.Mvc;
using System.Web.Routing;

namespace RetroMusicSite.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Music", action = "Audio" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Music", action = "Audio", id = UrlParameter.Optional }
            );
         
        }
    }
}
