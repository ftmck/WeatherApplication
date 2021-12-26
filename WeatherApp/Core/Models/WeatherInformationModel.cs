using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class WeatherInformationModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int Visibility { get; set; }
        public int DewPoint { get; set; }
        public int RelativeHumidity { get; set; }
        public int Pressure { get; set; }
    }
}
