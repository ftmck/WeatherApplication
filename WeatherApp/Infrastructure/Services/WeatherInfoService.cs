using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Models;

namespace WeatherApp.Infrastructure.Services
{
    public class WeatherInfoService : IWeatherInfoService
    {
        private readonly IWeatherInfoRepository _repo;
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<WeatherInfoService> _logger;
        //private TemperatureModel testData;

        public WeatherInfoService(
            IWeatherInfoRepository repo, 
            ICityRepository cityRepository,
            ILogger<WeatherInfoService> logger)
        {
            _repo = repo;
            _cityRepository = cityRepository;
            _logger = logger;
        }

        //public WeatherInfoService(TemperatureModel testData)
        //{
        //    this.testData = testData;
        //}


        public async Task<WeatherInformation> GetWeatherDataByCity(int cityId)
        {
            WeatherInformation selectedWeather = new WeatherInformation();

            var getWeather = await _repo.GetWeathersAsync();
            var getWeatherByCity = getWeather.Where(x => x.CityId == cityId).FirstOrDefault();
            var getCityName = await _cityRepository.GetCityByIdAsync(cityId);

            var getLocation = await _repo.GetLocationsAsync();
            var getSelectedLocation = getLocation.Where(x => x.WeatherId == getWeatherByCity.Id).FirstOrDefault();

            var getWind = await _repo.GetWindsAsync();
            var getSelectedWind = getWind.Where(x => x.WeatherId == getWeatherByCity.Id).FirstOrDefault();

            var getSky = await _repo.GetSkyConditionsAsync();
            var getSelectedSky = getSky.Where(x => x.WeatherId == getWeatherByCity.Id).FirstOrDefault();

            var getTemperature = await _repo.GetTemperaturesAsync();
            var getSelectedTemperature = getTemperature.Where(x => x.WeatherId == getWeatherByCity.Id).FirstOrDefault();

            #region Assign Data
            LocationModel locationData = new LocationModel();
            locationData.Latitude = getSelectedLocation.Latitude;
            locationData.Longitude = getSelectedLocation.Longitude;

            WindModel windData = new WindModel();
            windData.Degrees = getSelectedWind.Degrees;
            windData.Speed = getSelectedWind.Speed;

            SkyConditionModel skyData = new SkyConditionModel();
            skyData.Description = getSelectedSky.Description;
            skyData.Main = getSelectedSky.Main;

            TemperatureModel temperatureData = new TemperatureModel();
            temperatureData.Temperature = getSelectedTemperature.Temperature;
            temperatureData.Temperature_Max = getSelectedTemperature.Temperature_Max;
            temperatureData.Temperature_Min = getSelectedTemperature.Temperature_Min;
            #endregion

            #region convert temperature
            var convertedTemperature = await ConvertTemperature(temperatureData);
            #endregion

            #region Result Data
            selectedWeather.CityId = getWeatherByCity.CityId;
            selectedWeather.CityName = getCityName.Name;
            selectedWeather.Location = locationData;
            selectedWeather.Time = DateTime.Now.ToString();
            selectedWeather.Wind = windData;
            selectedWeather.Visibility = getWeatherByCity.Visibility;
            selectedWeather.SkyCondition = skyData;
            selectedWeather.Temperature = convertedTemperature;
            selectedWeather.DewPoint = getWeatherByCity.DewPoint;
            selectedWeather.RelativeHumidity = getWeatherByCity.RelativeHumidity;
            selectedWeather.Pressure = getWeatherByCity.Pressure;
            #endregion

            return selectedWeather;
        }

        public async Task<TemperatureModel> ConvertTemperature(TemperatureModel data)
        {
            TemperatureModel ResultConvert = new TemperatureModel();

            try
            {
                //convert Fahrenheit to Celcius
                ResultConvert.Temperature = data.Temperature == 0 ? 0 : Math.Round(((data.Temperature - 32) * 5 / 9), 2);
                ResultConvert.Temperature_Max = data.Temperature_Max == 0 ? 0 : Math.Round(((data.Temperature_Max - 32) * 5 / 9), 2);
                ResultConvert.Temperature_Min = data.Temperature_Min == 0 ? 0 : Math.Round(((data.Temperature_Min - 32) * 5 / 9), 2);

                //testData.Temperature = ResultConvert.Temperature;
                //testData.Temperature_Max = ResultConvert.Temperature_Max;
                //testData.Temperature_Min = ResultConvert.Temperature_Min;
            }
            catch (Exception ex) 
            {
                _logger.LogError("Error When Converting Temperature", ex.Message);
            }

            return ResultConvert;
        }
    }
}
