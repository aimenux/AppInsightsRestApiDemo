using System.Collections.Generic;
using System.Linq;
using App.Extractors.Payloads.AggregatedRequestsDuration;
using Newtonsoft.Json;

namespace App.Extractors
{
    public class AggregatedRequestsDurationExtractor : IExtractor
    {
        public ICollection<double> ExtractValues(string json)
        {
            var payload = JsonConvert.DeserializeObject<AggregatedRequestsDurationPayload>(json);
            return payload.Value.Segments.Select(x => x.AggregatedRequestsDuration.Avg).ToList();
        }
    }
}