using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Models;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.API.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(
            ICityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet("GetAllCities")]
        public async Task<ActionResult<List<CountryModel>>> GetAllCities()
        {
            var cities = await _cityService.GetAllCities();

            return Ok(cities);
        }

        [HttpGet("GetSelectedCity/{cityId}")]
        public async Task<ActionResult<CountryModel>> GetSelectedCity(int cityId)
        {
            var selectedCity = await _cityService.GetSelectedCity(cityId);

            return Ok(selectedCity);
        }

        [HttpGet("GetCityBasedCountry/{countryId}")]
        public async Task<ActionResult<CityModel>> GetCityBasedCountry(int countryId)
        {
            var selectedCityBasedCountry = await _cityService.GetSelectedCityFromCountry(countryId);

            return Ok(selectedCityBasedCountry);
        }
    }
}
