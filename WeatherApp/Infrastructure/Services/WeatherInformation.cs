using WeatherApp.Core.Models;

namespace WeatherApp.Infrastructure.Services
{
    public class WeatherInformation
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public LocationModel Location { get; set; }
        public string Time { get; set; }
        public WindModel Wind { get; set; }
        public int Visibility { get; set; }
        public SkyConditionModel SkyCondition { get; set; }
        public TemperatureModel Temperature { get; set; }
        public int DewPoint { get; set; }
        public int RelativeHumidity { get; set; }
        public int Pressure { get; set; }
    }
}