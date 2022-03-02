using Newtonsoft.Json;

namespace Shop.Core.Dto.Weather
{
    public class MaximumDto
    {
        [JsonProperty("DailyForecasts.Temperature.Maximum.Value")]
        public double Value { get; set; }

        [JsonProperty("DailyForecasts.Temperature.Maximum.Unit")]
        public string Unit { get; set; }

        [JsonProperty("DailyForecasts.Temperature.Maximum.UnitType")]
        public int UnitType { get; set; }
    }
}
