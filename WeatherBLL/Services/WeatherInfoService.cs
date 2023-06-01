using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WeatherDAL.Repositories;
using WeatherDOMAIN.Data.Contracts;
using WeatherDOMAIN.Data.DTOs;
using WeatherDOMAIN.Data.Models;
using WeatherDOMAIN.Data.ViewModels;

namespace WeatherBLL.Services
{
    public class WeatherInfoService : IWeatherInfoService
    {
        private readonly EfCoreCityRepository _cityRepository;
        private readonly EfCoreWeatherDataRepository _weatherDataRepository;
        private readonly EfCoreWeatherDetailRepository _weatherDetailRepository;

        public WeatherInfoService(EfCoreCityRepository cityRepository, EfCoreWeatherDataRepository weatherDataRepository, EfCoreWeatherDetailRepository weatherDetailRepository)
        {
            _cityRepository = cityRepository;
            _weatherDataRepository = weatherDataRepository;
            _weatherDetailRepository = weatherDetailRepository;
        }

        public async Task<WeatherData> GetWeatherInfo(string cityName)
        {
            var city = await _cityRepository.GetByName(cityName);
            var allWeatherData = await _weatherDataRepository.GetWeatherDataByCityId(city.Id);
            var latestWeatherData = allWeatherData.MaxBy(x=>x.SnapshotTime);
            var weatherDetails = await _weatherDetailRepository.GetWeatherDetailsByWeatherDataId(latestWeatherData.Id);
            latestWeatherData.WeatherDetails = weatherDetails;
            return latestWeatherData;
        }

        public async Task<double> GetAverageTemperatureForACity(string cityName, TimeFrame timeFrame)
        {
            var city = await _cityRepository.GetByName(cityName);
            var weatherDataInTimeFrame = await _weatherDataRepository.GetWeatherDataInsideATimeFrameByCityId(city.Id, timeFrame);
            return weatherDataInTimeFrame.Average(x => x.Temp);
        }

        public async Task<BiggestOscillationVM> GetTheBiggestOscillation(TimeFrame timeFrame)
        {
            //dohvati sve gradove
            var cities = await _cityRepository.GetAll();
            var biggestOscillation = new BiggestOscillationVM() { CityName="",Oscillation=0};
            double oscillation = 0;
            foreach(var city in cities)
            {
                city.WeatherDatas =await _weatherDataRepository.GetWeatherDataInsideATimeFrameByCityId(city.Id, timeFrame);
                oscillation = city.WeatherDatas.MaxBy(x => x.Temp_max).Temp_max - city.WeatherDatas.MinBy(x => x.Temp_min).Temp_min;
                if (oscillation > biggestOscillation.Oscillation)
                {
                    biggestOscillation.CityName = city.Name;
                    biggestOscillation.Oscillation=oscillation;
                }
            }
            return biggestOscillation;
        }
    }
}