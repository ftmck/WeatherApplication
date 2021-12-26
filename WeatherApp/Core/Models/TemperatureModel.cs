using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class TemperatureModel
    {
        public decimal Temperature { get; set; }
        public decimal Temperature_Max { get; set; }
        public decimal Temperature_Min { get; set; }
    }
}
