using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Infrastructure.Services
{
    public interface ICountryService
    {
        Task<List<CountryModel>> GetAllCountries();
        Task<CountryModel> GetSelectedCountry(int countryId);
    }
}
