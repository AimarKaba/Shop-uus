using Newtonsoft.Json;

namespace Shop.Core.Dto.Weather
{
    public class DirectionDto
    {
        [JsonProperty("DailyForecasts.Day.Wind.Direction.Degrees")]
        public double Degrees { get; set; }

        [JsonProperty("DailyForecasts.Day.Wind.Direction.Localized")]
        public string Localized { get; set; }

        [JsonProperty("DailyForecasts.Day.Wind.Direction.English")]
        public string English { get; set; }
    }
}
