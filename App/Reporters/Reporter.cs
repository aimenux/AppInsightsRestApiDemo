using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Extensions;
using App.Extractors;
using App.Metrics;
using App.Providers;

namespace App.Reporters
{
    public class Reporter : IReporter
    {
        private readonly IExtractorFactory _factory;
        private readonly IEnumerable<IMetric> _metrics;
        private readonly IAppInsightsProvider _appInsightsProvider;

        public Reporter(IExtractorFactory factory, IEnumerable<IMetric> metrics, IAppInsightsProvider appInsightsProvider)
        {
            _factory = factory;
            _metrics = metrics;
            _appInsightsProvider = appInsightsProvider;
        }

        public async Task PrintAsync()
        {
            foreach (var metric in _metrics)
            {
                var response = await _appInsightsProvider.GetInsights(metric.Query);
                var extractor = _factory.CreateExtractor(metric);
                var values = extractor.ExtractValues(response);
                var measurements = new Measurements(values);
                ConsoleColor.Blue.WriteLine($"Query {metric.Name} [{metric.Query}]");
                ConsoleColor.Green.WriteLine($"Measurements {measurements}");
                ConsoleColor.Gray.WriteLine($"Response: {response}");
            }
        }

        private class Measurements
        {
            private readonly double _min;
            private readonly double _max;
            private readonly double _avg;

            public Measurements(ICollection<double> values)
            {
                if (!values.Any())
                {
                    return;
                }

                _min = Math.Round(values.Min(), 2);
                _max = Math.Round(values.Max(), 2);
                _avg = Math.Round(values.Average(), 2);
            }

            public override string ToString()
            {
                return $"[Min = {_min} | Max = {_max} | Avg = {_avg}]";
            }
        }
    }
}