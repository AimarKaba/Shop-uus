using Newtonsoft.Json;

namespace Shop.Core.Dto.Weather
{
    public class IceDto
    {
        [JsonProperty("DailyForecasts.Day.Ice.Value")]
        public double Value { get; set; }

        [JsonProperty("DailyForecasts.Day.Ice.Value")]
        public string Unit { get; set; }

        [JsonProperty("DailyForecasts.Day.Ice.Value")]
        public int UnitType { get; set; }
    }
}
