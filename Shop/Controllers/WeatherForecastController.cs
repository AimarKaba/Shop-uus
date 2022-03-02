using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dtos.Weather;
using Shop.Core.ServiceInterface;
using Shop.Models.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public WeatherForecastController
            (
                IWeatherForecastServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        [HttpGet]
        public IActionResult SearchCity()
        {
            SearchCity model = new SearchCity();

            return View(model);
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCity vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecast", new { city = vm.CityName });
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            WeatherResultDto dto = new WeatherResultDto();

            var weatherResponse = _weatherForecastServices.WeatherDetail(dto);
            CityViewModel vm =  new CityViewModel();

            vm.EffectiveDate = dto.EffectiveDate;
            vm.EffectiveEpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.Category = dto.Category;
            vm.EndDate = dto.EndDate;
            vm.EndEpochDate = dto.EndEpochDate;
            vm.DailyForecastsDate = dto.DailyForecastsDate;
            vm.DailyForecastsEpochDate = dto.DailyForecastsEpochDate;

            vm.TempMinValue = dto.TempMinValue;
            vm.TempMinUnit = dto.TempMinUnit;
            vm.TempMinUnitType = dto.TempMinUnitType;

            vm.TempMaxValue = dto.TempMaxValue;
            vm.TempMaxUnit = dto.TempMaxUnit;
            vm.TempMaxUnitType = dto.TempMaxUnitType;

            vm.DayIcon = dto.DayIcon;
            vm.DayIconPhrase = dto.DayIconPhrase;
            vm.DayHasPrecipitation = dto.DayHasPrecipitation;
            vm.DayPrecipitationType = dto.DayPrecipitationType;
            vm.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.NightIcon = dto.NightIcon;
            vm.NightIconPhrase = dto.NightIconPhrase;
            vm.NightHasPrecipitation = dto.NightHasPrecipitation;
            vm.NightPrecipitationType = dto.NightPrecipitationType;
            vm.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;

            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;

            return View(vm);
        }
    }
}
