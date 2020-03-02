using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsFailed
{
    internal class RequestsFailed
    {
        [JsonProperty("sum")]
        public double Sum { get; set; }
    }
}