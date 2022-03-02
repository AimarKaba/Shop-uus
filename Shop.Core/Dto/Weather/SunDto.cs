using Newtonsoft.Json;

namespace Shop.Core.Dto.Weather
{
    public class SunDto
    {
        [JsonProperty("DailyForecasts.Sun.Rise")]
        public string Rise { get; set; }

        [JsonProperty("DailyForecasts.Sun.EpochRise")]
        public int EpochRise { get; set; }

        [JsonProperty("DailyForecasts.Sun.Set")]
        public string Set { get; set; }

        [JsonProperty("DailyForecasts.Sun.EpochSet")]
        public int EpochSet { get; set; }
    }
}