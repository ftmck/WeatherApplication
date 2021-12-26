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
    public class WeatherHeaderContextSeed
    {
        public static async Task SeedAsync(WeatherContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.WeatherHeader.Any())
                {
                    string fileLocation = @"C:\Users\fatimacikal\source\tech test\WeatherApp\WeatherApp\Infrastructure\Data\SeedData\weatherheader.json";
                    var weatherHeaderData = File.ReadAllText(fileLocation);
                    //var countriesData = File.ReadAllText("../Infrastructure/Data/SeedData/countries.json");

                    var weatherHeader = JsonSerializer.Deserialize<List<WeatherHeader>>(weatherHeaderData);

                    foreach (var item in weatherHeader)
                    {
                        context.WeatherHeader.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<WeatherHeaderContextSeed>();
                logger.LogError(ex.Message);
                //throw;
            }
        }
    }
}
