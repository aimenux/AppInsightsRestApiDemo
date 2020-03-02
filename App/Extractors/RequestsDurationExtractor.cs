using System.Collections.Generic;
using System.Linq;
using App.Extractors.Payloads.RequestsDuration;
using Newtonsoft.Json;

namespace App.Extractors
{
    public class RequestsDurationExtractor : IExtractor
    {
        public ICollection<double> ExtractValues(string json)
        {
            var payload = JsonConvert.DeserializeObject<RequestsDurationPayload>(json);
            return payload.Value.Segments.Select(x => x.RequestsDuration.Avg).ToList();
        }
    }
}