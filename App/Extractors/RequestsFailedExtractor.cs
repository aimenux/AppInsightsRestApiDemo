using System.Collections.Generic;
using System.Linq;
using App.Extractors.Payloads;
using App.Extractors.Payloads.RequestsFailed;
using Newtonsoft.Json;

namespace App.Extractors
{
    public class RequestsFailedExtractor : IExtractor
    {
        public ICollection<double> ExtractValues(string json)
        {
            var payload = JsonConvert.DeserializeObject<RequestsFailedPayload>(json);
            return payload.Value.Segments.Select(x => x.RequestsFailed.Sum).ToList();
        }
    }
}