using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.API.Entities;

namespace WeatherApp.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country> GetCountryByIdAsync(int id);
        Task<IReadOnlyList<Country>> GetCountriesAsync();
    }
}
