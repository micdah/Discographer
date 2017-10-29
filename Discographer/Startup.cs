using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Discographer.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Discographer.Domain;
using System.Linq;
using Discographer.Domain.Entities;
using Serilog;
using Microsoft.EntityFrameworkCore;

namespace Discographer
{
    public class Startup
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<Startup>();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IContainer Container { get; private set; }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Setup AutoFac
            Container = new ContainerBuilder()
                .InstallServiceCollection(services, Configuration)
                .InstallCore()
                .Build();

            using (var scope = Container.BeginLifetimeScope()) 
            {
                var context = Container.Resolve<DiscographerContext>();

                // Ensure database is up to date
                context.Database.Migrate();

                // Ensure there is a ApplicationSettings record
                Log.Debug("Checking if there exists an ApplicationSettings record");

                if (!context.ApplicationSettings.Any()) 
                {
                    Log.Information("Creating default ApplicationSettings");;
                    context.ApplicationSettings.Add(new ApplicationSettings
                    {
                        DiscogsToken = null
                    });
                    context.SaveChanges();
                }
            }

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
