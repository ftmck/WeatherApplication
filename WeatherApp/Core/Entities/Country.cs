using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Core.Entities;

namespace WeatherApp.API.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<City> City { get; set; }
    }
}
