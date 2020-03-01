namespace App.Metrics
{
    public abstract class AbstractMetric : IMetric
    {
        public int Timespan { get; }
        public int Interval { get; }
        public abstract string Name { get; }
        public abstract string Query { get; }

        protected AbstractMetric() : this(30, 5)
        {
        }

        protected AbstractMetric(int timespan, int interval)
        {
            Timespan = timespan;
            Interval = interval;
        }
    }
}