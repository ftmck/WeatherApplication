using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.API.Entities;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Models;
using WeatherApp.Infrastructure.Services;

namespace WeatherApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        //private readonly ICountryRepository _repo;
        //public CountryController(ICountryRepository repo)
        //{
        //    _repo = repo;
        //}

        private readonly ICountryService _countryService;

        public CountryController(
            ICountryService countryService)
        {
            _countryService = countryService;
        }


        //[HttpGet("GetAllCountries")]
        //public async Task<ResponseResult<List<CountryModel>>> GetAllCountries()
        //{
        //    var countries = await _countryService.GetAllCountries();

        //    return countries;
        //    //return Ok(countries);
        //}

        [HttpGet("GetAllCountries")]
        public async Task<ActionResult<List<CountryModel>>> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountries();

            //return countries;
            return Ok(countries);
        }

        [HttpGet("GetSelectedCountry/{countryId}")]
        public async Task<ActionResult<CountryModel>> GetSelectedCountry(int countryId)
        {
            var selectedCountry = await _countryService.GetSelectedCountry(countryId);

            return Ok(selectedCountry);
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Country>>> GetCountries()
        //{
        //    var countries = await _repo.GetCountriesAsync();

        //    return Ok(countries);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Country>> GetCountryById(int id)
        //{
        //    return await _repo.GetCountryByIdAsync(id);
        //}

        #region
        //[HttpGet]
        //public string GetCountry()
        //{
        //    return "list of countries";
        //}

        //[HttpGet("{id}")]
        //public string GetSelectedCountry()
        //{
        //    return "single country";
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
        #endregion
    }
}
