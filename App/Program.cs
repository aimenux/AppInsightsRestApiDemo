using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using App.Extensions;
using App.Extractors;
using App.Metrics;
using App.Providers;
using App.Reporters;
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

            services.AddTransient<IReporter, Reporter>();
            services.AddTransient<IMetric, RequestsNumberMetric>();
            services.AddTransient<IMetric, RequestsFailedMetric>();
            services.AddTransient<IMetric, RequestsDurationMetric>();
            services.AddTransient<IMetric, ExceptionsNumberMetric>();
            services.AddTransient<IExtractorFactory, ExtractorFactory>();
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
            var reporter = serviceProvider.GetRequiredService<IReporter>();
            await reporter.PrintAsync();
            
            ConsoleColor.Yellow.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }
    }
}
