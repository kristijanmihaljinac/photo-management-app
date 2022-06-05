using Common.Mediator.Core;
using Microsoft.Extensions.DependencyInjection;
using PhotoManagementApp.Test.Helpers;
using PhotoManagementApp.Test.Models.Command;
using System;

namespace PhotoManagementApp.Test
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceProvider _serviceProvider = null;
            _serviceProvider = CreateServiceCollection();

            var mediator = _serviceProvider.GetService<IMediator>();
            var simpleQuery = new SimpleCommand() { Name = "moje ime" };

            var result = mediator.HandleAsync(simpleQuery).Result;
            Console.WriteLine(result.Message);

            DisposeServices(_serviceProvider);
        }

        public static ServiceProvider CreateServiceCollection()
        {
            var services = new ServiceCollection();

            services
                .AddSimpleMediator()
                .AddSimpleMediatorMiddleware();

            return services.BuildServiceProvider();
        }



        private static void DisposeServices(ServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
