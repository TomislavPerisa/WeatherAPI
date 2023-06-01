using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDOMAIN.Data.Contracts;

namespace WeatherDOMAIN.Data.Models
{
    public class WeatherDetail : IEntity
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }

        //Navigation properties
        [ForeignKey("weatherDatas")]
        public int IdWeatherData { get; set; }
        public WeatherData WeatherData { get; set; }
    }
}
