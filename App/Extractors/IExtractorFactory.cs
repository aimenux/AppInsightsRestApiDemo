using App.Metrics;
using App.Queries;

namespace App.Extractors
{
    public interface IExtractorFactory
    {
        IExtractor CreateExtractor(IMetric metric);
        IExtractor CreateExtractor(IQuery query);
    }
}