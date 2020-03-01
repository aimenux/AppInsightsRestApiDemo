using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Extensions;
using App.Metrics;
using App.Providers;

namespace App.Reporters
{
    public class Reporter : IReporter
    {
        private readonly IEnumerable<IMetric> _metrics;
        private readonly IAppInsightsProvider _appInsightsProvider;

        public Reporter(IEnumerable<IMetric> metrics, IAppInsightsProvider appInsightsProvider)
        {
            _metrics = metrics;
            _appInsightsProvider = appInsightsProvider;
        }

        public async Task PrintAsync()
        {
            foreach (var metric in _metrics)
            {
                var response = await _appInsightsProvider.GetInsights(metric.Query);
                ConsoleColor.Blue.WriteLine($"Query {metric.Name} [{metric.Query}]");
                ConsoleColor.Gray.WriteLine($"Response: {response}");
            }
        }
    }
}