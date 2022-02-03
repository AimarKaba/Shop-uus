using System;

namespace Shop.Models.Weather
{
    public class Day
    {
        public Int32 Icon { get; set; }
        public string IconPhrase { get; set; }
        public LocalSource LocalSource { get; set; }
        public Boolean HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public Int32 PrecipitationProbability { get; set; }
        public Int32 ThunderstormProbability { get; set; }
        public Int32 RainProbability { get; set; }
        public Int32 SnowProbability { get; set; }
        public Int32 IceProbability { get; set; }
        public Wind Wind { get; set; }
        public WindGust WindGust { get; set; }
        public TotalLiquid TotalLiquid { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public Ice Ice { get; set; }
        public float HoursOfPrecipitation { get; set; }
        public float HoursOfRain { get; set; }
        public Int32 CloudCover { get; set; }
        public Evapotranspiration Evapotranspiration { get; set; }
        public SolarIrradiance SolarIrradiance { get; set; }
    }
}