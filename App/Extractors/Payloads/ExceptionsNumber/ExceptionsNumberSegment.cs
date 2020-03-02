using System;
using Newtonsoft.Json;

namespace App.Extractors.Payloads.ExceptionsNumber
{
    internal class ExceptionsNumberSegment
    {
        [JsonProperty("start")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime EndDate { get; set; }

        [JsonProperty("exceptions/count")]
        public ExceptionsNumber ExceptionsNumber { get; set; }
    }
}