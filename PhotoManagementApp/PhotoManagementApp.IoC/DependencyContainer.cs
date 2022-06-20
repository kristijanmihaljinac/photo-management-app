using Autofac;
using Microsoft.Extensions.Configuration;

namespace PhotoManagementApp.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterModules(ContainerBuilder builder, IConfiguration configuration)
        {
            string photoManagementDbConnectionString = configuration.GetConnectionString("PhotoManagementDb");

            builder.RegisterModule(new Modules.Application.MediatorModule());
            builder.RegisterModule(new Modules.Application.ApplicationModule());
            builder.RegisterModule(new Modules.Application.InfrastructureModule(photoManagementDbConnectionString));

        }
    }
}
