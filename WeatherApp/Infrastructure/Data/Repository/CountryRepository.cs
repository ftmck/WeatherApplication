using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.API.Data;
using WeatherApp.API.Entities;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Infrastructure.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly WeatherContext _context;
        public CountryRepository(WeatherContext context)
        {
            _context = context;
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<IReadOnlyList<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }        
    }
}
