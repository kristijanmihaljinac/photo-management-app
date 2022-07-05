using Autofac;
using PhotoManagementApp.Application.Package.Shared.Repositories;
using PhotoManagementApp.Infrastructure;
using PhotoManagementApp.Infrastructure.Repositories.Package;
using System.Reflection;

namespace PhotoManagementApp.IoC.Modules.Application
{

    internal class InfrastructureModule : Autofac.Module
    {
        private readonly string _connectionString;
        internal InfrastructureModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {

            var appAssembly = Assembly.Load("PhotoManagementApp.Infrastructure");

            builder.RegisterType<DbContextFactory>().As<IDbContextFactory>()
                .WithParameter("connectionString", _connectionString);

            builder.RegisterType<System.Data.SqlClient.SqlConnection>().As<System.Data.IDbConnection>()
                .WithParameter("connectionString", _connectionString);


            builder.RegisterType<IPackageReadOnlyRepository>().As<PackageReadOnlyRepository>();

            //builder.RegisterAssemblyTypes(appAssembly)
            //.AsClosedTypesOf(typeof(ICodebookRepository<>))
            //.AsImplementedInterfaces();

        }
    }
}
