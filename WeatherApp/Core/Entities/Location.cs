using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Entities
{
    public class Location : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Longitude { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Latitude { get; set; }
        public int WeatherId { get; set; }
        public WeatherHeader Weather { get; set; }
    }
}
