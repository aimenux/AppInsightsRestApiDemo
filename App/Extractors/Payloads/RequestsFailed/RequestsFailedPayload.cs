using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsFailed
{
    internal class RequestsFailedPayload
    {
        [JsonProperty("value")]
        public RequestsFailedValue Value { get; set; }
    }
}
