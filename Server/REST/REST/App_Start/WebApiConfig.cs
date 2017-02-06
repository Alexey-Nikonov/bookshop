using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace REST
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API
            config.EnableCors();

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{resource}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
