using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Infrastructure.Services
{
    public interface ICityService
    {
        Task<List<CityModel>> GetAllCities();
        Task<CityModel> GetSelectedCity(int cityId);
        Task<List<CityModel>> GetSelectedCityFromCountry(int countryId);
    }
}
