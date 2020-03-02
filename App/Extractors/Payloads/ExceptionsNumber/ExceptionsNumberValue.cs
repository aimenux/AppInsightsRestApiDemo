using System;
using System.Collections.Generic;
using App.Extractors.Payloads.RequestsFailed;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.ExceptionsNumber
{
    internal class ExceptionsNumberValue
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime EndDate { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("segments")]
        public List<ExceptionsNumberSegment> Segments { get; set; }
    }
}