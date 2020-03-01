namespace App.Metrics
{
    public interface IMetric
    {
        public int Timespan { get; }
        public int Interval { get; }
        public string Name { get; }
        public string Query { get; }
    }
}
