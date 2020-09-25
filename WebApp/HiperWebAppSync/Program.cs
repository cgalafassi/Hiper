using Autofac;
using Autofac.Extensions.DependencyInjection;

using HiperWebApp.Application.Services.HttpClients;
using HiperWebApp.Domain.Core.Interfaces.Repositorys;
using HiperWebApp.Infra.Data;
using HiperWebApp.Infra.Repository;
using HiperWebApp.Infrastructure.CrossCutting.IoC;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;

namespace HiperWebAppSync
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices((hostContext, services) =>
                {
                    string uriApi = hostContext.Configuration.GetSection("ApiURIs:HiperApi").Value;
                    if (string.IsNullOrWhiteSpace(uriApi))
                        throw new InvalidOperationException("Can not start the service without a uri for HiperApi!");

                    string connectionString = hostContext.Configuration.GetSection("ConnectionStrings:SqlConnectionString").Value;
                    if (string.IsNullOrWhiteSpace(connectionString))
                        throw new InvalidOperationException("Can not start the service without a connection string!");


                    services.AddDbContext<ApplicationContext>(options =>
                                    options.UseSqlServer(connectionString));

                    services.AddTransient<IProductRepository, ProductRepository>();

                    services.AddHttpClient<HiperApiClient>(client =>
                    {
                        client.BaseAddress = new Uri(uriApi);
                    });

                    services.AddHostedService<Worker>();
                })
                .ConfigureContainer<ContainerBuilder>((context, services) =>
                {
                    services.RegisterModule(new ModuleIOC());
                });
    }
}
