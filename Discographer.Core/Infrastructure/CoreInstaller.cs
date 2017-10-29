using Autofac;
using Autofac.Extensions.DependencyInjection;
using Discographer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discographer.Core.Infrastructure
{
    public static class CoreInstaller
    {
        public static ContainerBuilder InstallServiceCollection(this ContainerBuilder builder, IServiceCollection serviceCollection, IConfiguration configuration) 
        {
            serviceCollection.AddDbContext<DiscographerContext>(
                (_, o) => o.UseSqlite(configuration.GetConnectionString("Sqlite")));

            builder.Populate(serviceCollection);
            return builder;
        }

        public static ContainerBuilder InstallCore(this ContainerBuilder builder)
        {
            return builder;
        }
    }
}
