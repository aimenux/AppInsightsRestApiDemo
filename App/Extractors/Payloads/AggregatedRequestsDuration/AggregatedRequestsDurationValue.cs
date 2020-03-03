using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.AggregatedRequestsDuration
{
    internal class AggregatedRequestsDurationValue
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime EndDate { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("segments")]
        public List<AggregatedRequestsDurationSegment> Segments { get; set; }
    }
}