﻿using System.Security.Policy;
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
            name: "Default2",
            url: "{artistId}",
            defaults: new { controller = "Music", action = "Audio" },
            constraints: new { artistId = "\\d+" }
        );

            routes.MapRoute(
            name: "Default",
            url: "{category}/{page}",
            defaults: new { controller = "Music", action = "Artist", 
                category = "Все", page = 1},
            constraints: new { page = "\\d+" }
        );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
