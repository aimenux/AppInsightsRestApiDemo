using System;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsFailed
{
    internal class RequestsFailedSegment
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime EndDate { get; set; }

        [JsonProperty("requests/failed")]
        public RequestsFailed RequestsFailed { get; set; }
    }
}