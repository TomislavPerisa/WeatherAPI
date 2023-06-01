using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDOMAIN.Data.Models;

namespace WeatherDAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(x => x.WeatherDatas)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.IdCity)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<WeatherData>()
                .HasMany(x => x.WeatherDetails)
                .WithOne(x => x.WeatherData)
                .HasForeignKey(x => x.IdWeatherData)
                .HasPrincipalKey(x => x.Id);
        }

        public DbSet<City> cities { get; set; }
        public DbSet<WeatherData> weatherDatas { get; set; }
        public DbSet<WeatherDetail> weatherDetails { get; set; }
    }
}
