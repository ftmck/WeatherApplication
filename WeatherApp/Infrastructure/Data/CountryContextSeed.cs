using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.API.Data;
using WeatherApp.API.Entities;

namespace WeatherApp.Infrastructure.Data
{
    public class CountryContextSeed
    {
        public static async Task SeedAsync(WeatherContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Countries.Any())
                {                    
                    string fileLocation = @"C:\Users\fatimacikal\source\tech test\WeatherApp\WeatherApp\Infrastructure\Data\SeedData\countries.json";
                    var countriesData = File.ReadAllText(fileLocation);
                    //var countriesData = File.ReadAllText("../Infrastructure/Data/SeedData/countries.json");

                    var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);

                    foreach (var item in countries)
                    {
                        context.Countries.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<CountryContextSeed>();
                logger.LogError(ex.Message);
                //throw;
            }
        }
    }
}
