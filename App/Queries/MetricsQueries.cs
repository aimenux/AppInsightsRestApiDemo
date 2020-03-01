using System.Collections.Generic;

namespace App.Queries
{
    public static class MetricsQueries
    {
        private const int Timespan = 30;
        private const int Interval = 10;

        public static string RequestsNumberQuery = $"metrics/requests/count?timespan=PT{Timespan}M&interval=PT{Interval}M";
        public static string RequestsDurationQuery = $"metrics/requests/duration?timespan=PT{Timespan}M&interval=PT{Interval}M";
        public static string RequestsFailedQuery = $"metrics/requests/failed?timespan=PT{Timespan}M&interval=PT{Interval}M";
        public static string ExceptionsNumberQuery = $"metrics/exceptions/count?timespan=PT{Timespan}M&interval=PT{Interval}M";

        public static IDictionary<string, string> All = new Dictionary<string, string>
        {
            [nameof(RequestsNumberQuery)] = RequestsNumberQuery,
            [nameof(RequestsDurationQuery)] = RequestsDurationQuery,
            [nameof(RequestsFailedQuery)] = RequestsFailedQuery,
            [nameof(ExceptionsNumberQuery)] = ExceptionsNumberQuery
        };
    }
}
