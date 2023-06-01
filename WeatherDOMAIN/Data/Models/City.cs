using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDOMAIN.Data.Contracts;

namespace WeatherDOMAIN.Data.Models
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int IdExternal { get; set; }

        //Navigation properties
        public List<WeatherData> WeatherDatas { get; set; }
    }
}
