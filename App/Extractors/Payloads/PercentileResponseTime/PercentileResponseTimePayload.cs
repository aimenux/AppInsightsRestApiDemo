using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.PercentileResponseTime
{
    internal class PercentileResponseTimePayload
    {
        [JsonProperty("tables")]
        public List<PercentileResponseTimeTable> Tables { get; set; }
    }
}
