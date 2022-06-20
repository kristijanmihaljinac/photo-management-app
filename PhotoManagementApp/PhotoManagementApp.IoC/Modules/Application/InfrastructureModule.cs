using Autofac;
using PhotoManagementApp.Infrastructure;
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


            //builder.RegisterAssemblyTypes(appAssembly)
            //.AsClosedTypesOf(typeof(ICodebookRepository<>))
            //.AsImplementedInterfaces();

        }
    }
}
