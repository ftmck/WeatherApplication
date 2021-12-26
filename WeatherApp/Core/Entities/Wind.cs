using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Entities
{
    public class Wind : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Speed { get;set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Degrees { get;set; }
        public int WeatherId { get; set; }
        public WeatherHeader Weather { get; set; }
    }
}
