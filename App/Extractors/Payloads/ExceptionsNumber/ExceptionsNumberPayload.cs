using App.Extractors.Payloads.RequestsFailed;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.ExceptionsNumber
{
    internal class ExceptionsNumberPayload
    {
        [JsonProperty("value")]
        public ExceptionsNumberValue Value { get; set; }
    }
}
