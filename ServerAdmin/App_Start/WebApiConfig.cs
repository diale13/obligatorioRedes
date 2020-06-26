using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServerAdmin
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
        }
    }
}
