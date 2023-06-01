using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDOMAIN.Data.Contracts;

namespace WeatherDOMAIN.Data.Models
{
    public class WeatherData : IEntity
    {
        public int Id { get; set; }
        public DateTime SnapshotTime { get; set; }
        public int All { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double? Rain1h { get; set; }
        public double? Rain3h { get; set; }
        public double? Snow1h { get; set; }
        public double? Snow3h { get; set; }
        public string Base { get; set; }
        public int Visibility { get; set; }
        public int Dt { get; set; }
        public int Type { get; set; }
        public DateTime? SunriseTime { get; set; }
        public DateTime? SunsetTime { get; set; }
        public double Speed { get; set; }
        public int Deg { get; set; }

        //Navigation properties
        [ForeignKey("cities")]
        public int IdCity { get; set; }
        public City City { get; set; }
        public List<WeatherDetail> WeatherDetails { get; set; }
    }
}