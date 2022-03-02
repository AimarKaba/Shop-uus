using System.Collections.Generic;

namespace Shop.Core.Dto.Weather
{
    public class WeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastsDto> DailyForecasts { get; set; }
    }
}
