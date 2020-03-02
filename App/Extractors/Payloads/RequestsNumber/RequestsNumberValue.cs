using System;
using System.Collections.Generic;
using App.Extractors.Payloads.RequestsFailed;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.RequestsNumber
{
    internal class RequestsNumberValue
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime EndDate { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("segments")]
        public List<RequestsNumberSegment> Segments { get; set; }
    }
}