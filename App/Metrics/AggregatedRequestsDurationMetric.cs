namespace App.Metrics
{
    public class AggregatedRequestsDurationMetric : AbstractMetric
    {
        public override string Name { get; } = nameof(AggregatedRequestsDurationMetric);
        public override string Query => $"metrics/requests/duration?timespan=PT{Timespan}M&interval=PT{Interval}M&aggregation=min%2Cmax%2Cavg";
    }
}