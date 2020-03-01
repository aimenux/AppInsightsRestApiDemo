namespace App.Metrics
{
    public class RequestsFailedMetric : AbstractMetric
    {
        public override string Name { get; } = nameof(RequestsFailedMetric);
        public override string Query => $"metrics/requests/failed?timespan=PT{Timespan}M&interval=PT{Interval}M";
    }
}