using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;

namespace Discographer.Core.Infrastructure
{
    public static class CoreInstaller
    {
        public static ContainerBuilder InstallServiceCollection(this ContainerBuilder builder, IServiceCollection serviceCollection) 
        {
            builder.Populate(serviceCollection);
            return builder;
        }

        public static ContainerBuilder InstallCore(this ContainerBuilder builder)
        {
            return builder;
        }
    }
}
