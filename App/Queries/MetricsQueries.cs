using System.Collections.Generic;

namespace App.Queries
{
    public static class MetricsQueries
    {
        public static string RequestsNumberQuery = "metrics/requests/count?timespan=PT2H&interval=PT30M";
        public static string RequestsDurationQuery = "metrics/requests/duration?timespan=PT2H&interval=PT30M";
        public static string RequestsFailedQuery = "metrics/requests/failed?timespan=PT2H&interval=PT30M";
        public static string ExceptionsNumberQuery = "metrics/exceptions/count?timespan=PT2H&interval=PT30M";

        public static IDictionary<string, string> All = new Dictionary<string, string>
        {
            [nameof(RequestsNumberQuery)] = RequestsNumberQuery,
            [nameof(RequestsDurationQuery)] = RequestsDurationQuery,
            [nameof(RequestsFailedQuery)] = RequestsFailedQuery,
            [nameof(ExceptionsNumberQuery)] = ExceptionsNumberQuery
        };
    }
}
