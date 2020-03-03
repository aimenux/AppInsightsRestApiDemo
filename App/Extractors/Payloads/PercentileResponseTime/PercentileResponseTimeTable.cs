using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.PercentileResponseTime
{
    internal class PercentileResponseTimeTable
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("columns")]
        public List<PercentileResponseTimeColumn> Columns { get; set; }
        
        [JsonProperty("rows")]
        public List<PercentileResponseTimeRow> Rows { get; set; }
    }
}