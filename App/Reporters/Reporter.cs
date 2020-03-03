using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Extensions;
using App.Extractors;
using App.Metrics;
using App.Providers;
using App.Queries;

namespace App.Reporters
{
    public class Reporter : IReporter
    {
        private readonly IExtractorFactory _factory;
        private readonly IEnumerable<IQuery> _queries;
        private readonly IEnumerable<IMetric> _metrics;
        private readonly IAppInsightsProvider _appInsightsProvider;

        public Reporter(
            IExtractorFactory factory,
            IEnumerable<IQuery> queries,
            IEnumerable<IMetric> metrics,
            IAppInsightsProvider appInsightsProvider)
        {
            _factory = factory;
            _queries = queries;
            _metrics = metrics;
            _appInsightsProvider = appInsightsProvider;
        }

        public async Task PrintAsync()
        {
            foreach (var query in _queries)
            {
                var response = await _appInsightsProvider.GetInsights(query.Query);
                var extractor = _factory.CreateExtractor(query);
                var values = extractor.ExtractValues(response);
                var measurements = new Measurements(values);
                measurements.PrintMeasurements(query.Name, query.Query, response);
            }

            foreach (var metric in _metrics)
            {
                var response = await _appInsightsProvider.GetInsights(metric.Query);
                var extractor = _factory.CreateExtractor(metric);
                var values = extractor.ExtractValues(response);
                var measurements = new Measurements(values);
                measurements.PrintMeasurements(metric.Name, metric.Query, response);
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

            public void PrintMeasurements(string name, string query, string response)
            {
                ConsoleColor.Blue.WriteLine($"Query {name} [{query}]");
                ConsoleColor.Green.WriteLine($"Measurements {this}");
                ConsoleColor.Gray.WriteLine($"Response: {response}");
            }

            public override string ToString()
            {
                return $"[Min = {_min} | Max = {_max} | Avg = {_avg}]";
            }
        }
    }
}