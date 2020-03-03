namespace App.Queries
{
    public class PercentileResponseTimeQuery : AbstractQuery
    {
        private const string Timestamp = "timestamp%20%3E%3D%20ago(1h)";

        private const string Percentiles = "percentiles(duration%2C50%2C95)";

        public override string Name { get; } = "Percentile (50th & 95th) response time for the last hour";

        public override string Query { get; } = $"query?query=requests%20%7C%20where%20{Timestamp}%20%7C%20summarize%20{Percentiles}";
    }
}
