using Assignment5.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Assignment5
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new Q4CustomExceptionFilter());
        }
    }
}
