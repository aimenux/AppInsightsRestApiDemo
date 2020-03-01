namespace App.Queries
{
    public class RequestsDurationMetric : AbstractMetric
    {
        public override string Name { get; } = nameof(RequestsDurationMetric);
        public override string Query => $"metrics/requests/duration?timespan=PT{Timespan}M&interval=PT{Interval}M";
    }
}