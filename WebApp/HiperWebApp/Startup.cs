using Autofac;

using HiperWebApp.Domain.Core.Interfaces.Repositorys;
using HiperWebApp.Infra.Data;
using HiperWebApp.Infra.Repository;
using HiperWebApp.Infrastructure.CrossCutting.IoC;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HiperWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            string connectionString = Configuration.GetConnectionString("SqlConnectionString");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString)
            );
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        public void ConfigureContainer(ContainerBuilder Builder) => Builder.RegisterModule(new ModuleIOC());

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
