using Autofac;
using FluentValidation;
using System.Reflection;

namespace PhotoManagementApp.IoC.Modules.Application
{
    internal class ApplicationModule : Autofac.Module
    {
      
        protected override void Load(ContainerBuilder builder)
        {



            var appAssembly = Assembly.Load("PhotoManagementApp.Application");

            builder.RegisterAssemblyTypes(appAssembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces();

            //builder.RegisterType<PackageSavingRepository>().As<IPackageRepository>();



            base.Load(builder);
        }
    }
}
