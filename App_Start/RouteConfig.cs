using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DEMO5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductLayout",
                url: "{Home}/{produce_layout_1}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
                defaults: new { controller = "Home", action = "produce_layout_1" }
            );
            routes.MapRoute(
              name:"Aboutus",
              url: "{Home}/{about_us}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "about_us"}
          );
            routes.MapRoute(
              name: "Cart",
              url: "{Home}/{cart}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "cart" }
          );
            routes.MapRoute(
              name: "CheckOut",
              url: "{Home}/{checkout}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "checkout" }
          );
            routes.MapRoute(
              name: "FAQS",
              url: "{Home}/{faqs}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "faqs" }
          );
            routes.MapRoute(
              name: "Login",
              url: "{Home}/{login}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "login" }
          );
            routes.MapRoute(
              name: "REGISTER",
              url: "{Home}/{register}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "register" }
          );
            routes.MapRoute(
              name: "BODYCARE",
              url: "{Home}/{Bodycare}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "Bodycare" }
          );
            routes.MapRoute(
              name: "FACIALCARE",
              url: "{Home}/{Facialcare}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "Facialcare" }
          );
            routes.MapRoute(
              name: "MAKEUP",
              url: "{Home}/{Makeup}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "Makeup" }
          );
            routes.MapRoute(
              name: "PERFUME",
              url: "{Home}/{Perfume}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "Perfume" }
          );
            routes.MapRoute(
              name: "HAIRCARE",
              url: "{Home}/{Haircare}/{id}", // Đường dẫn URL mà bạn muốn sử dụng
              defaults: new { controller = "Home", action = "Haircare" }
          );
        }
    }
}
