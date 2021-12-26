using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.API.Data;
using WeatherApp.Core.Entities;

namespace WeatherApp.Infrastructure.Data
{
    public class CityContextSeed
    {
        public static async Task SeedAsync(WeatherContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Cities.Any())
                {
                    string fileLocation = @"C:\Users\fatimacikal\source\tech test\WeatherApp\WeatherApp\Infrastructure\Data\SeedData\cities.json";
                    var citiesData = File.ReadAllText(fileLocation);
                    //var countriesData = File.ReadAllText("../Infrastructure/Data/SeedData/countries.json");

                    var cities = JsonSerializer.Deserialize<List<City>>(citiesData);

                    foreach (var item in cities)
                    {
                        context.Cities.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<CityContextSeed>();
                logger.LogError(ex.Message);
                //throw;
            }
        }
    }
}
