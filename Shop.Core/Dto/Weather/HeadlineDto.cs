using Newtonsoft.Json;
using System;


namespace Shop.Core.Dto.Weather
{
    public class HeadlineDto
    {
        [JsonProperty("EffectiveDate")]
        public string EffectiveDate { get; set; }

        [JsonProperty("EffectiveEpochDate")]
        public Int64 EffectiveEpochDate { get; set; }

        [JsonProperty("Severity")]
        public int Severity { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        [JsonProperty("EndEpochDate")]
        public Int64 EndEpochDate { get; set; }

        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }


    }
}
