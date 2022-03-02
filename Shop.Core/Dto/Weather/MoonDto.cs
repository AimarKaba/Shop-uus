using Newtonsoft.Json;
using System;


namespace Shop.Core.Dto.Weather
{
    public class MoonDto
    {
        [JsonProperty("DailyForecasts.Sun.Rise")]
        public string Rise { get; set; }

        [JsonProperty("DailyForecasts.Sun.EpochRise")]
        public Int64 EpochRise { get; set; }

        [JsonProperty("DailyForecasts.Sun.Set")]
        public string Set { get; set; }

        [JsonProperty("DailyForecasts.Sun.EpochSet")]
        public Int64 EpochSet { get; set; }

        [JsonProperty("DailyForecasts.Sun.Phase")]
        public string Phase { get; set; }

        [JsonProperty("DailyForecasts.Sun.Age")]
        public int Age { get; set; }
    }
}
