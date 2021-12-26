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
    public class CityRepository : ICityRepository
    {
        private readonly WeatherContext _context;
        public CityRepository(WeatherContext context)
        {
            _context = context;
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<IReadOnlyList<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
