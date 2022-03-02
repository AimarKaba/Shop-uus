using Shop.Core.Dtos.Weather;
using System.Threading.Tasks;


namespace Shop.Core.ServiceInterface
{
    public interface IWeatherForecastServices : IApplicationService
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}
