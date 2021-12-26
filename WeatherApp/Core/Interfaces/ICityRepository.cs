using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Entities;

namespace WeatherApp.Core.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityByIdAsync(int id);
        Task<IReadOnlyList<City>> GetCitiesAsync();
    }
}
