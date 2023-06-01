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
    public class EfCoreCityRepository : EfCoreRepository<City, AppDbContext>
    {
        public EfCoreCityRepository(AppDbContext context) : base(context) { }

        public async Task<City> GetByName(string cityName)
        {
            return await _context.cities.FirstOrDefaultAsync(x => x.Name == cityName);
        }
    }
}
