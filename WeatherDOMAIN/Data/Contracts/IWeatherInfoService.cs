using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDOMAIN.Data.DTOs;
using WeatherDOMAIN.Data.Models;
using WeatherDOMAIN.Data.ViewModels;

namespace WeatherDOMAIN.Data.Contracts
{
    public interface IWeatherInfoService
    {
        Task<WeatherData> GetWeatherInfo(string cityName);
        Task<double> GetAverageTemperatureForACity(string name, TimeFrame timeFrame);
        Task<BiggestOscillationVM> GetTheBiggestOscillation(TimeFrame timeFrame);
    }
}
