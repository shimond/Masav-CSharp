using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MasavWebApi
{

    //api/products/1 - GET
    //api/products POST
    //api/products/1 - DELETE 
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
