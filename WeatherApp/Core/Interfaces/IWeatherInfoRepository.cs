using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Entities;

namespace WeatherApp.Core.Interfaces
{
    public interface IWeatherInfoRepository
    {        
        Task<IReadOnlyList<WeatherHeader>> GetWeathersAsync();
        Task<WeatherHeader> GetWeatherByIdAsync(int id);
        Task<IReadOnlyList<Location>> GetLocationsAsync();
        Task<IReadOnlyList<Wind>> GetWindsAsync();
        Task<IReadOnlyList<SkyCondition>> GetSkyConditionsAsync();
        Task<IReadOnlyList<TemperatureDetail>> GetTemperaturesAsync();
    }
}
