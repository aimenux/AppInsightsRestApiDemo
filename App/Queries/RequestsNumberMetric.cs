namespace App.Queries
{
    public class RequestsNumberMetric : AbstractMetric
    {
        public override string Name { get; } = nameof(RequestsNumberMetric);
        public override string Query => $"metrics/requests/count?timespan=PT{Timespan}M&interval=PT{Interval}M";
    }
}