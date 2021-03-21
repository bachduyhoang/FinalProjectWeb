using System.Web.Mvc;
using System.Web.Routing;

namespace FinalProjectWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Product Details ",
            url: "product/detail-{id}",
            defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
            namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
            name: "Cart Default",
            url: "cart",
            defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
            name: "Cart Update",
            url: "cart/update",
            defaults: new { controller = "Cart", action = "Update", id = UrlParameter.Optional },
            namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
            name: "Cart CheckOut",
            url: "cart/checkout",
            defaults: new { controller = "Cart", action = "CheckOut", id = UrlParameter.Optional },
            namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
            name: "Delete All Cart ",
            url: "cart/deleteall",
            defaults: new { controller = "Cart", action = "Delete", id = UrlParameter.Optional },
            namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
            name: "Delete Item Cart ",
            url: "cart/delete",
            defaults: new { controller = "Cart", action = "DeleteItem", id = UrlParameter.Optional },
            namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
            name: "Add To Cart ",
            url: "add-to-cart",
            defaults: new { controller = "Cart", action = "Add", id = UrlParameter.Optional },
            namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Product Brand",
                url: "product/{brand}",
                defaults: new { controller = "Product", action = "Brand", id = UrlParameter.Optional },
                namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Product Brand 1",
                url: "product",
                defaults: new { controller = "Product", action = "Brand", id = UrlParameter.Optional },
                namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Home",
                url: "home",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FinalProjectWeb.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FinalProjectWeb.Controllers" }
            );


        }
    }
}
