using AppCityAPI.Models;
using AppInterface;
using AppInterfaces;
using AppRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace AppCityAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ICityRepository, CityRepository>();
            container.RegisterType<ICityService, CityService>();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<ITokenService, TokenService>();
            container.RegisterType<IWeatherForecastService, WeatherForecastService>();
            config.DependencyResolver = new UnityResolver(container);

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
