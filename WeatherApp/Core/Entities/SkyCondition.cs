using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Entities
{
    public class SkyCondition : BaseEntity
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public int WeatherId { get; set; }
        public WeatherHeader Weather { get; set; }
    }
}
