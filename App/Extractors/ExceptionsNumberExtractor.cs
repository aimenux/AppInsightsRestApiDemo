using System.Collections.Generic;
using System.Linq;
using App.Extractors.Payloads.ExceptionsNumber;
using Newtonsoft.Json;

namespace App.Extractors
{
    public class ExceptionsNumberExtractor : IExtractor
    {
        public ICollection<double> ExtractValues(string json)
        {
            var payload = JsonConvert.DeserializeObject<ExceptionsNumberPayload>(json);
            return payload.Value.Segments.Select(x => x.ExceptionsNumber.Sum).ToList();
        }
    }
}