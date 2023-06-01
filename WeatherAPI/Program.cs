using WeatherDAL.Data;
using Microsoft.EntityFrameworkCore;
using WeatherDAL.Repositories;
using System.Text.Json.Serialization;
using WeatherBLL.Services;
using WeatherDOMAIN.Data.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Custom services
builder.Services.AddScoped<EfCoreCityRepository>();
builder.Services.AddScoped<EfCoreWeatherDataRepository>();
builder.Services.AddScoped<EfCoreWeatherDetailRepository>();
builder.Services.AddScoped<IWeatherInfoService,WeatherInfoService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Database Configuration (Entity Framework Core)
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
