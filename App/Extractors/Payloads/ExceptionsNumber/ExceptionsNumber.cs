using Newtonsoft.Json;

namespace App.Extractors.Payloads.ExceptionsNumber
{
    internal class ExceptionsNumber
    {
        [JsonProperty("sum")]
        public double Sum { get; set; }
    }
}