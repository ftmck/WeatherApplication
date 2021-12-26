using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.API.Data;
using WeatherApp.Core.Entities;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Infrastructure.Data.Repository
{
    public class WeatherInfoRepository : IWeatherInfoRepository
    {
        private readonly WeatherContext _context;
        public WeatherInfoRepository(WeatherContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<WeatherHeader>> GetWeathersAsync()
        {
            return await _context.WeatherHeader.ToListAsync();
        }

        public async Task<WeatherHeader> GetWeatherByIdAsync(int id)
        {
            return await _context.WeatherHeader.FindAsync(id);
        }

        //Location
        public async Task<IReadOnlyList<Location>> GetLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        //Wind
        public async Task<IReadOnlyList<Wind>> GetWindsAsync()
        {
            return await _context.Winds.ToListAsync();
        }

        //Sky
        public async Task<IReadOnlyList<SkyCondition>> GetSkyConditionsAsync()
        {
            return await _context.SkyConditions.ToListAsync();
        }

        //Temperature
        public async Task<IReadOnlyList<TemperatureDetail>> GetTemperaturesAsync()
        {
            return await _context.TemperatureDetails.ToListAsync();
        }
    }
}
