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
    public class DetailDataContextSeed
    {
        public static async Task SeedAsync(WeatherContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //Location
                if (!context.Locations.Any())
                {
                    string fileLocation = @"C:\Users\fatimacikal\source\tech test\WeatherApp\WeatherApp\Infrastructure\Data\SeedData\location.json";
                    var locationData = File.ReadAllText(fileLocation);

                    var locations = JsonSerializer.Deserialize<List<Location>>(locationData);

                    foreach (var item in locations)
                    {
                        context.Locations.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                //Wind
                if (!context.Winds.Any())
                {
                    string fileLocation = @"C:\Users\fatimacikal\source\tech test\WeatherApp\WeatherApp\Infrastructure\Data\SeedData\wind.json";
                    var windData = File.ReadAllText(fileLocation);

                    var winds = JsonSerializer.Deserialize<List<Wind>>(windData);

                    foreach (var item in winds)
                    {
                        context.Winds.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                //SkyCondition
                if (!context.SkyConditions.Any())
                {
                    string fileLocation = @"C:\Users\fatimacikal\source\tech test\WeatherApp\WeatherApp\Infrastructure\Data\SeedData\skycondition.json";
                    var skyData = File.ReadAllText(fileLocation);

                    var skyconditions = JsonSerializer.Deserialize<List<SkyCondition>>(skyData);

                    foreach (var item in skyconditions)
                    {
                        context.SkyConditions.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                //TemperatureDetail
                if (!context.TemperatureDetails.Any())
                {
                    string fileLocation = @"C:\Users\fatimacikal\source\tech test\WeatherApp\WeatherApp\Infrastructure\Data\SeedData\temperaturedetail.json";
                    var temperatureData = File.ReadAllText(fileLocation);

                    var temperatures = JsonSerializer.Deserialize<List<TemperatureDetail>>(temperatureData);

                    foreach (var item in temperatures)
                    {
                        context.TemperatureDetails.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DetailDataContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
