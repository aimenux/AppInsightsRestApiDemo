using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsDuration
{
    internal class RequestsDurationPayload
    {
        [JsonProperty("value")]
        public RequestsDurationValue Value { get; set; }
    }
}
