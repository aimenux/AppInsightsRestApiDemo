using System.Collections.Generic;
using System.Linq;
using App.Extractors.Payloads.RequestsNumber;
using Newtonsoft.Json;

namespace App.Extractors
{
    public class RequestsNumberExtractor : IExtractor
    {
        public ICollection<double> ExtractValues(string json)
        {
            var payload = JsonConvert.DeserializeObject<RequestsNumberPayload>(json);
            return payload.Value.Segments.Select(x => x.RequestsNumber.Sum).ToList();
        }
    }
}