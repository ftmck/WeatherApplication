using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Models;

namespace WeatherApp.Infrastructure.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repo;
        public CityService(ICityRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CityModel>> GetAllCities()
        {
            List<CityModel> allCities = new List<CityModel>();

            var getAllCities = await _repo.GetCitiesAsync();

            foreach (var item in getAllCities)
            {
                var assignData = new CityModel();

                assignData.Id = item.Id;
                assignData.CityName = item.Name;
                assignData.CountryId = item.CountryId;

                allCities.Add(assignData);
            }

            return allCities;
        }

        public async Task<CityModel> GetSelectedCity(int cityId)
        {
            CityModel selectedCity = new CityModel();

            var getCity = await _repo.GetCityByIdAsync(cityId);

            selectedCity.Id = getCity.Id;
            selectedCity.CityName = getCity.Name;
            selectedCity.CountryId = getCity.CountryId;

            return selectedCity;
        }

        public async Task<List<CityModel>> GetSelectedCityFromCountry(int countryId)
        {
            List<CityModel> selectedCities = new List<CityModel>();

            var getAllCities = await _repo.GetCitiesAsync();
            var getSelectedCities = getAllCities.Where(x => x.CountryId == countryId).ToList();

            foreach (var item in getSelectedCities)
            {
                var assignData = new CityModel();

                assignData.Id = item.Id;
                assignData.CityName = item.Name;
                assignData.CountryId = item.CountryId;

                selectedCities.Add(assignData);
            }

            return selectedCities;
        }
    }
}
