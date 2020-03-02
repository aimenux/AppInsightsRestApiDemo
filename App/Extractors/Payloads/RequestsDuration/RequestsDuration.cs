using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsDuration
{
    internal class RequestsDuration
    {
        [JsonProperty("avg")]
        public double Avg { get; set; }
    }
}