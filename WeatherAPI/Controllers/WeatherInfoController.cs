using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherBLL.Services;
using WeatherDOMAIN.Data.Contracts;
using WeatherDOMAIN.Data.DTOs;
using WeatherDOMAIN.Data.ViewModels;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherInfoController : ControllerBase
    {
        private readonly IWeatherInfoService _weatherInfoService;

        public WeatherInfoController(IWeatherInfoService weatherInfoService)
        {
            _weatherInfoService = weatherInfoService;
        }

        [HttpGet("/weather/{name}")]
        public async Task<IActionResult> GetWeatherInfo(string name)
        {
            try
            {
                var weatherInfo = await _weatherInfoService.GetWeatherInfo(name);
                return Ok(weatherInfo);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpPost("/avgTemp/{name}")]
        public async Task<IActionResult> GetAverageTemperature(string name, [FromBody] TimeFrame timeFrame)
        {
            try
            {
                var averageTemp = await _weatherInfoService.GetAverageTemperatureForACity(name, timeFrame);
                return Ok(averageTemp);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        [HttpPost("/oscillation")]
        public async Task<BiggestOscillationVM> GetTheBiggestOscillation([FromBody] TimeFrame timeFrame)
        {
            try
            {
                var biggestOscillation = await _weatherInfoService.GetTheBiggestOscillation(timeFrame);
                return biggestOscillation;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
