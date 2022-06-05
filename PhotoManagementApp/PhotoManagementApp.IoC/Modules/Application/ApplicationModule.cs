using Autofac;
using PhotoManagementApp.Application.Repositories;
using PhotoManagementApp.Infrastructure;
using PhotoManagementApp.Infrastructure.Repositories.Package;

namespace PhotoManagementApp.IoC.Modules.Application
{
    public class ApplicationModule : Module
    {
        private readonly string _connectionString;

        public ApplicationModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>()
                .WithParameter("connectionString", _connectionString);

            builder.RegisterType<PackageRepository>().As<IPackageRepository>();


            base.Load(builder);
        }
    }
}
