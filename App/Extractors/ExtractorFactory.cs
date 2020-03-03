using System;
using App.Metrics;
using App.Queries;

namespace App.Extractors
{
    public class ExtractorFactory : IExtractorFactory
    {
        public IExtractor CreateExtractor(IMetric metric)
        {
            return metric switch
            {
                RequestsNumberMetric _ => new RequestsNumberExtractor(),
                RequestsFailedMetric _ => new RequestsFailedExtractor(),
                RequestsDurationMetric _ => new RequestsDurationExtractor(),
                ExceptionsNumberMetric _ => new ExceptionsNumberExtractor(),
                AggregatedRequestsDurationMetric _ => new AggregatedRequestsDurationExtractor(),
                _ => throw new ArgumentOutOfRangeException(nameof(metric))
            };
        }

        public IExtractor CreateExtractor(IQuery query)
        {
            return query switch
            {
                PercentileResponseTimeQuery _ => new PercentileResponseTimeExtractor(),
                _ => throw new ArgumentOutOfRangeException(nameof(query))
            };
        }
    }
}