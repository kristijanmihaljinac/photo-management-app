using Autofac;
using Common.Mediator.Core;
using Common.Mediator.Middleware;
using System.Reflection;

namespace PhotoManagementApp.IoC.Modules.Application
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var appAssembly = Assembly.Load("PhotoManagementApp.Application");
            var infraAssembly = Assembly.Load("PhotoManagementApp.Infrastructure");
            var domainAssembly = Assembly.Load("PhotoManagementApp.Domain");

            var assemblies = new List<Assembly> { appAssembly, infraAssembly, domainAssembly };

            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IMessageHandler<,>)).AsImplementedInterfaces();

                AddMiddleware(assembly, builder);
            }

            builder.Register<ServiceFactoryDelegate>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return context.Resolve;
            });

            builder.RegisterType<ServiceFactory>().AsImplementedInterfaces();
            builder.RegisterType<Mediator>().AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(MessageProcessor<,>)).AsImplementedInterfaces();

            base.Load(builder);
        }

        private static void AddMiddleware(Assembly assembly, ContainerBuilder builder)
        {
            var middlewareTypes = assembly.GetTypes().Where(t =>
            {
                return t.GetTypeInfo()
                    .ImplementedInterfaces.Any(
                        i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMiddleware<,>));
            });

            foreach (var middlewareType in middlewareTypes)
            {
                if (middlewareType.IsGenericType)
                {
                    builder.RegisterGeneric(middlewareType).AsImplementedInterfaces();
                }
                else
                {
                    builder.RegisterType(middlewareType).AsImplementedInterfaces();
                }
            }
        }
    }
}
