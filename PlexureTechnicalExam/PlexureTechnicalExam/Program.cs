using System;
using Exercise1;
using Exercise1.Facades;
using Exercise1.Facades.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace PlexureTechnicalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create service collection and configure our services
            var services = ConfigureServices();
            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            // Kick off our actual code
            serviceProvider.GetService<AsyncApplication>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            //Configure Dependency Injection
            services.AddTransient<IUrlProvider, UrlProvider>();
            services.AddTransient<IResourcesFacade, ResourcesFacade>();
            services.AddTransient<AsyncApplication>();

            return services;
        }
    }
}
