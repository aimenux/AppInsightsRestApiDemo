using Newtonsoft.Json;

namespace App.Extractors.Payloads.AggregatedRequestsDuration
{
    internal class AggregatedRequestsDurationPayload
    {
        [JsonProperty("value")]
        public AggregatedRequestsDurationValue Value { get; set; }
    }
}
