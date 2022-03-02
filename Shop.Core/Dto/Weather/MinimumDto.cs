using Newtonsoft.Json;

namespace Shop.Core.Dto.Weather
{
    public class MinimumDto
    {
        [JsonProperty("DailyForecasts.Temperature.Minimum.Value")]
        public double Value { get; set; }

        [JsonProperty("DailyForecasts.Temperature.Minimum.Unit")]
        public string Unit { get; set; }

        [JsonProperty("DailyForecasts.Temperature.Minimum.UnitType")]
        public int UnitType { get; set; }
    }
}
