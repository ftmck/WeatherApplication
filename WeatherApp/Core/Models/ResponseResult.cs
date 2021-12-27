using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class ResponseResult<T> : ResponseModel
    {
        public T Result { get; set; }
    }
}
