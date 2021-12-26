using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Infrastructure.Services
{
    public interface IWeatherInfoService
    {
        Task<WeatherInformation> GetWeatherDataByCity(int cityId);
    }
}
