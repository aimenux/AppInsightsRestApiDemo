using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsNumber
{
    internal class RequestsNumber
    {
        [JsonProperty("sum")]
        public double Sum { get; set; }
    }
}