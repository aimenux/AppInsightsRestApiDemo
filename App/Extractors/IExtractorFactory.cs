using App.Metrics;

namespace App.Extractors
{
    public interface IExtractorFactory
    {
        IExtractor CreateExtractor(IMetric metric);
    }
}