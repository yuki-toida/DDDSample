using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.UI.Web;

namespace Sample.Test
{
    internal class TestConfiguration
    {
        static TestConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            var config = builder.Build();

            var startup = new Startup(config);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        internal static IServiceProvider ServiceProvider { get; }
    }
}
