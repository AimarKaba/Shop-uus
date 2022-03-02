using Newtonsoft.Json;

namespace Shop.Core.Dto.Weather
{
    public class LocalSourceDto
    {
        [JsonProperty("DailyForecasts.Day.LocalSource.Id")]
        public int Id { get; set; }

        [JsonProperty("DailyForecasts.Day.LocalSource.Name")]
        public string Name { get; set; }

        [JsonProperty("DailyForecasts.Day.LocalSource.WeatherCode")]
        public string WeatherCode { get; set; }
    }
}
