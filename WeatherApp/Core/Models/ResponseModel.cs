using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Core.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public ResponseModel()
        {
            this.Message = "";
            this.Success = true;
        }
    }
}
