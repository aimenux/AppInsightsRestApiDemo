using System.Collections.Generic;
using System.Linq;
using App.Extractors.Payloads.PercentileResponseTime;
using Newtonsoft.Json;

namespace App.Extractors
{
    public class PercentileResponseTimeExtractor : IExtractor
    {
        public ICollection<double> ExtractValues(string json)
        {
            var payload = JsonConvert.DeserializeObject<PercentileResponseTimePayload>(json);
            var rows = payload.Tables.SelectMany(x => x.Rows);
            var values = rows.Select(x => x.FirstOrDefault()).ToList();
            return values;
        }
    }
}