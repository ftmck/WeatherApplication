using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.API.Controllers
{
    public class WeatherInfoController : Controller
    {
        private readonly IWeatherInfoService _weatherInfoService;

        public WeatherInfoController(
            IWeatherInfoService weatherInfoService)
        {
            _weatherInfoService = weatherInfoService;
        }

        [HttpGet("GetWeatherByCity/{cityId}")]
        public async Task<ActionResult<WeatherInformation>> GetWeatherByCity(int cityId)
        {
            var selectedWeather = await _weatherInfoService.GetWeatherDataByCity(cityId);

            if (selectedWeather is null)
            {
                return NotFound();
            }

            return Ok(selectedWeather);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
