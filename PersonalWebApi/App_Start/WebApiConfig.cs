using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using PersonalWebApi.Services.TicTacToe;
using PersonalWebApi.Services.TicTacToe.Interfaces;

namespace PersonalWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<ITicTacToeService, TicTacToeService>(new HierarchicalLifetimeManager());


            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
