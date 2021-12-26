using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Entities
{
    public class TemperatureDetail : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Temperature { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Temperature_Max { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Temperature_Min { get; set; }
        public int WeatherId { get; set; }
        public WeatherHeader Weather { get; set; }
    }
}
