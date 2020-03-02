using System;
using App.Metrics;

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
                _ => throw new ArgumentOutOfRangeException(nameof(metric))
            };
        }
    }
}