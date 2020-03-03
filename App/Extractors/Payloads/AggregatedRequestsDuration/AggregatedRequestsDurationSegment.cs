using System;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.AggregatedRequestsDuration
{
    internal class AggregatedRequestsDurationSegment
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime EndDate { get; set; }

        [JsonProperty("requests/duration")]
        public AggregatedRequestsDuration AggregatedRequestsDuration { get; set; }
    }
}