using Newtonsoft.Json;

namespace App.Extractors.Payloads.AggregatedRequestsDuration
{
    internal class AggregatedRequestsDuration
    {
        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

        [JsonProperty("avg")]
        public double Avg { get; set; }
    }
}