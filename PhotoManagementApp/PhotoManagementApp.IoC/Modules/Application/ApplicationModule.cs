using Autofac;
using FluentValidation;
using PhotoManagementApp.Application.Repositories;
using PhotoManagementApp.Infrastructure;
using PhotoManagementApp.Infrastructure.Repositories.Package;
using System.Reflection;

namespace PhotoManagementApp.IoC.Modules.Application
{
    public class ApplicationModule : Autofac.Module
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


            var appAssembly = Assembly.Load("PhotoManagementApp.Application");

            builder.RegisterAssemblyTypes(appAssembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces();

            builder.RegisterType<PackageRepository>().As<IPackageRepository>();



            base.Load(builder);
        }
    }
}
