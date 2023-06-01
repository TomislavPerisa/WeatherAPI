using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDAL.Data;
using WeatherDOMAIN.Data.Models;

namespace WeatherDAL.Repositories
{
    public class EfCoreWeatherDetailRepository : EfCoreRepository<WeatherDetail, AppDbContext>
    {
        public EfCoreWeatherDetailRepository(AppDbContext context) : base(context) { }

        public async Task<List<WeatherDetail>> GetWeatherDetailsByWeatherDataId(int weatherDataId)
        {
            return await _context.weatherDetails.Where(x => x.IdWeatherData== weatherDataId).ToListAsync();
        }
    }
}
