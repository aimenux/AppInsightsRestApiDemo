using System;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsDuration
{
    internal class RequestsDurationSegment
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime EndDate { get; set; }

        [JsonProperty("requests/duration")]
        public RequestsDuration RequestsDuration { get; set; }
    }
}