namespace App.Queries
{
    public class ExceptionsNumberMetric : AbstractMetric
    {
        public override string Name { get; } = nameof(ExceptionsNumberMetric);
        public override string Query => $"metrics/exceptions/count?timespan=PT{Timespan}M&interval=PT{Interval}M";
    }
}