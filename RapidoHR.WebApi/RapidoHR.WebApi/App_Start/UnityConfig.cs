using RapidoHR.WebApi.Repository;
using RapidoHR.WebApi.Repository.Entity;
using RapidoHR.WebApi.Repository.Interfaces;
using RapidoHR.WebApi.Services;
using RapidoHR.WebApi.Services.Interfaces;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace RapidoHR.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register entities/context.
            container.RegisterType<IObjectContextAdapter, RapidoERP_KMBEntities>(new PerThreadLifetimeManager());

            // Register Unit of work.
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IEmployeeDetailService, EmployeeDetailService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}