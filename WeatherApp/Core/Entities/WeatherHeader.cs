using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Entities
{
    public class WeatherHeader : BaseEntity
    {
        public int CityId { get; set; }
        public int Visibility { get; set; }
        public int DewPoint { get; set; }
        public int RelativeHumidity { get; set; }
        public int Pressure { get; set; }
        public City City { get; set; }

        public ICollection<Location> Location { get; set; }
        public ICollection<Wind> Wind { get; set; }
        public ICollection<SkyCondition> SkyCondition { get; set; }
        public ICollection<TemperatureDetail> TemperatureDetail { get; set; }
    }
}
