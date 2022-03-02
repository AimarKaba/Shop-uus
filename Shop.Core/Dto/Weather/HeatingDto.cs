using Newtonsoft.Json;

namespace Shop.Core.Dto.Weather
{
    public class HeatingDto
    {
        [JsonProperty("DailyForecasts.DegreeDaySummary.Heating.Value")]
        public double Value { get; set; }

        [JsonProperty("DailyForecasts.DegreeDaySummary.Heating.Unit")]
        public string Unit { get; set; }

        [JsonProperty("DailyForecasts.DegreeDaySummary.Heating.UnitType")]
        public int UnitType { get; set; }
    }
}
