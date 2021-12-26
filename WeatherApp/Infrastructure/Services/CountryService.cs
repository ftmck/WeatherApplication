using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Models;

namespace WeatherApp.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repo;
        public CountryService(ICountryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CountryModel>> GetAllCountries()
        {
            List<CountryModel> allCountries = new List<CountryModel>();

            var getAllCountries = await _repo.GetCountriesAsync();

            foreach (var item in getAllCountries)
            {
                var assignData = new CountryModel();

                assignData.Id = item.Id;
                assignData.Name = item.Name;

                allCountries.Add(assignData);
            }

            return allCountries;
        }

        public async Task<CountryModel> GetSelectedCountry(int countryId)
        {
            CountryModel selectedCountry = new CountryModel();

            var getCountry = await _repo.GetCountryByIdAsync(countryId);

            selectedCountry.Id = getCountry.Id;
            selectedCountry.Name = getCountry.Name;

            return selectedCountry;
        }
    }
}
