using BLL.Interfaces;
using BLL.Services;
using DAL.DBExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace PL.ServicesExtensions
{
    ////public static class WebApiConfig
    ////{
    ////    public static void Register(HttpConfiguration config)
    ////    {
    ////        var container = new UnityContainer();
    ////        container.RegisterType<IRepository, EfRepository>();
            
    ////        config.MapHttpAttributeRoutes();
    ////        container.RegisterType<IMaterialService, MaterialService>();
    ////        config.DependencyResolver = new UnityResolver(container);

    ////        // Other Web API configuration not shown.
    ////    }
    ////}
}
