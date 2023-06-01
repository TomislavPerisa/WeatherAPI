using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WeatherDAL.Data;
using WeatherDOMAIN.Data.DTOs;
using WeatherDOMAIN.Data.Models;

namespace WeatherDAL.Repositories
{
    public class EfCoreWeatherDataRepository : EfCoreRepository<WeatherData, AppDbContext>
    {
        public EfCoreWeatherDataRepository(AppDbContext context) : base(context) { }

        public async Task<List<WeatherData>> GetWeatherDataByCityId(int cityId)
        {
            return await _context.weatherDatas.Where(x => x.IdCity == cityId).ToListAsync();
        }

        public async Task<List<WeatherData>> GetWeatherDataInsideATimeFrameByCityId(int cityId, TimeFrame timeFrame)
        {
            return await _context.weatherDatas.Where(x => x.IdCity == cityId && x.SnapshotTime >= timeFrame.StartTime && x.SnapshotTime <= timeFrame.EndTime).ToListAsync();
        }
    }
}
