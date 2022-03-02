using Newtonsoft.Json;
using Shop.Core.Dtos.Weather;


namespace Shop.Core.Dto.Weather
{
    public class NightDto
    {
        [JsonProperty("")]
        public int Icon { get; set; }

        [JsonProperty("")]
        public string IconPhrase { get; set; }

        [JsonProperty("")]
        public LocalSourceDto LocalSource { get; set; }

        [JsonProperty("")]
        public bool HasPrecipitation { get; set; }

        [JsonProperty("")]
        public string PrecipitationType { get; set; }

        [JsonProperty("")]
        public string PrecipitationIntensity { get; set; }

        [JsonProperty("")]
        public string ShortPhrase { get; set; }

        [JsonProperty("")]
        public string LongPhrase { get; set; }

        [JsonProperty("")]
        public int PrecipitationProbability { get; set; }

        [JsonProperty("")]
        public int ThunderstormProbability { get; set; }

        [JsonProperty("")]
        public int RainProbability { get; set; }

        [JsonProperty("")]
        public int SnowProbability { get; set; }

        [JsonProperty("")]
        public int IceProbability { get; set; }
        public WindDto Wind { get; set; }
        public WindGustDto WindGust { get; set; }
        public TotalLiquidDto TotalLiquid { get; set; }
        public RainDto Rain { get; set; }
        public SnowDto Snow { get; set; }
        public IceDto Ice { get; set; }

        [JsonProperty("")]
        public float HoursOfPrecipitation { get; set; }

        [JsonProperty("")]
        public float HoursOfRain { get; set; }

        [JsonProperty("")]
        public int CloudCover { get; set; }
        public EvapotranspirationDto Evapotranspiration { get; set; }
        public SolarIrradianceDto SolarIrradiance { get; set; }

        [JsonProperty("")]
        public string Sources { get; set; }

        [JsonProperty("")]
        public string MobileLink { get; set; }

        [JsonProperty("")]
        public string Link { get; set; }
    }
}
