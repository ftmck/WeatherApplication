﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}
