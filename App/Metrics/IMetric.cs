namespace App.Metrics
{
    public interface IMetric
    {
        int Timespan { get; }
        int Interval { get; }
        string Name { get; }
        string Query { get; }
    }
}
