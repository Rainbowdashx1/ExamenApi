using ExamenApi.Models;
using ExamenApi.Models.Bl;
using ExamenApi.Models.Bl.Interface;
using ExamenApi.Models.Dao;
using ExamenApi.Models.Dao.Interface;
using System.Web.Http;
using Unity;

namespace ExamenApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IClienteBl, ClienteBl>(new Unity.Lifetime.HierarchicalLifetimeManager());
            container.RegisterType<IClientesDao, ClientesDao>(new Unity.Lifetime.HierarchicalLifetimeManager());
            container.RegisterType<IBDContextSqlLite, BDContextSqlLite>(new Unity.Lifetime.HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            // Configuración y servicios de Web API
            // Rutas de Web API
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
