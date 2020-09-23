using Autofac;

using HiperAPI.Application.Interfaces;
using HiperAPI.Application.Services;
using HiperAPI.Domain.Core.Interfaces.Repositorys;
using HiperAPI.Domain.Core.Interfaces.Services;
using HiperAPI.Domain.Services;
using HiperAPI.Infrastructure.CrossCutting.Adapter.Interfaces;
using HiperAPI.Infrastructure.CrossCutting.Adapter.Mappers;
using HiperAPI.Infrastructure.Repository;

namespace HiperAPI.Infrastructure.CrossCutting.IoC
{
    public class ConfigurationIOC
    {
        internal static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceProduct>().As<IApplicationServiceProduct>();
            #endregion

            #region IOC Services
            builder.RegisterType<ProductService>().As<IProductService>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<ProductMapper>().As<IProductMapper>();
            #endregion

            #endregion
        }
    }
}
