using Autofac;

using HiperWebApp.Application.Interfaces;
using HiperWebApp.Application.Services;
using HiperWebApp.Domain.Core.Interfaces.Repositorys;
using HiperWebApp.Domain.Core.Interfaces.Services;
using HiperWebApp.Domain.Services;
using HiperWebApp.Infra.Repository;

namespace HiperWebApp.Infrastructure.CrossCutting.IoC
{
    public class ConfigurationIOC
    {
        internal static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceProduct>().As<IApplicationServiceProduct>();
            builder.RegisterType<ApplicationServiceSync>().As<IApplicationServiceSync>();
            #endregion

            #region IOC Services
            builder.RegisterType<ProductService>().As<IProductService>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            #endregion

            #endregion
        }
    }
}
