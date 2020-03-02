using System;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsNumber
{
    internal class RequestsNumberSegment
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime EndDate { get; set; }

        [JsonProperty("requests/count")]
        public RequestsNumber RequestsNumber { get; set; }
    }
}