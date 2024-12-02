using Microsoft.AspNetCore.Mvc;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.Dto.WeatherDtos.OpenWeatherDtos;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.OpenWeathers;

namespace ShopTARge23.Controllers
{
    public class OpenWeathersController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;

        public OpenWeathersController
            (IOpenWeatherServices openWeatherServices)
        {
            _openWeatherServices = openWeatherServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchCity(OpenWeatherSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "OpenWeathers", new { city = model.CityName });
            }
            return View(model);
        }

        public IActionResult City(string city)
        {
            OpenWeatherResultDto dto = new();
            dto.City = city;

            _openWeatherServices.OpenWeatherResult(dto);
            OpenWeatherViewModel vm = new();

            vm.City = dto.City;
            vm.Temp = dto.Temp;
            vm.FeelsLike = dto.FeelsLike;
            vm.Humidity = dto.Humidity;
            vm.Pressure = dto.Pressure;
            vm.WindSpeed = dto.WindSpeed;
            vm.Description = dto.Description;

            return View(vm);
        }
    }
}