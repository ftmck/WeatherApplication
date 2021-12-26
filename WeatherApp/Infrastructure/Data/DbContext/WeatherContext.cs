using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.API.Entities;
using WeatherApp.Core.Entities;

namespace WeatherApp.API.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<WeatherHeader> WeatherHeader { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Wind> Winds { get; set; }
        public DbSet<SkyCondition> SkyConditions { get; set; }
        public DbSet<TemperatureDetail> TemperatureDetails { get; set; }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
