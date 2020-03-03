using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsNumber
{
    internal class RequestsNumberPayload
    {
        [JsonProperty("value")]
        public RequestsNumberValue Value { get; set; }
    }
}
