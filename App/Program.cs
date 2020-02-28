using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using App.Extensions;
using App.Providers;
using App.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace App
{
    public static class Program
    {
        public static async Task Main()
        {
            var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            services.Configure<Settings>(configuration.GetSection(nameof(Settings)));
            services.AddHttpClient<IAppInsightsProvider, AppInsightsProvider>((provider, client) =>
            {
                var settings = provider.GetService<IOptions<Settings>>().Value;
                var mediaTypeWithQualityHeaderValue = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(mediaTypeWithQualityHeaderValue);
                client.DefaultRequestHeaders.Add("x-api-key", settings.ApiKey);
                client.Timeout = TimeSpan.FromSeconds(settings.TimeoutInSeconds);
            });

            var serviceProvider = services.BuildServiceProvider();
            var appInsightsProvider = serviceProvider.GetRequiredService<IAppInsightsProvider>();

            foreach (var (name, query) in MetricsQueries.All)
            {
                var response = await appInsightsProvider.GetInsights(query);
                ConsoleColor.Blue.WriteLine($"Query {name}: {query}");
                ConsoleColor.Gray.WriteLine($"Response: {response}");
            }
            
            ConsoleColor.Yellow.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }
    }
}
