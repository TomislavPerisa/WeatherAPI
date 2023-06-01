﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherDAL.Data;

#nullable disable

namespace WeatherDAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230528180645_AddExternalIdColumnToCitiesTable")]
    partial class AddExternalIdColumnToCitiesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeatherDOMAIN.Data.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExternalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("WeatherDOMAIN.Data.Models.WeatherData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("All")
                        .HasColumnType("int");

                    b.Property<string>("Base")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Deg")
                        .HasColumnType("int");

                    b.Property<int>("Dt")
                        .HasColumnType("int");

                    b.Property<double>("Feels_like")
                        .HasColumnType("float");

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<int>("IdCity")
                        .HasColumnType("int");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lon")
                        .HasColumnType("float");

                    b.Property<int>("Pressure")
                        .HasColumnType("int");

                    b.Property<double?>("Rain1h")
                        .HasColumnType("float");

                    b.Property<double?>("Rain3h")
                        .HasColumnType("float");

                    b.Property<DateTime>("SnapshotTime")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Snow1h")
                        .HasColumnType("float");

                    b.Property<double?>("Snow3h")
                        .HasColumnType("float");

                    b.Property<double>("Speed")
                        .HasColumnType("float");

                    b.Property<DateTime?>("SunriseTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SunsetTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Temp")
                        .HasColumnType("float");

                    b.Property<double>("Temp_max")
                        .HasColumnType("float");

                    b.Property<double>("Temp_min")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Visibility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("weatherDatas");
                });

            modelBuilder.Entity("WeatherDOMAIN.Data.Models.WeatherDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdWeatherData")
                        .HasColumnType("int");

                    b.Property<string>("Main")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeatherDataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId");

                    b.ToTable("weatherDetails");
                });

            modelBuilder.Entity("WeatherDOMAIN.Data.Models.WeatherData", b =>
                {
                    b.HasOne("WeatherDOMAIN.Data.Models.City", "City")
                        .WithMany("WeatherDatas")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("WeatherDOMAIN.Data.Models.WeatherDetail", b =>
                {
                    b.HasOne("WeatherDOMAIN.Data.Models.WeatherData", "WeatherData")
                        .WithMany("WeatherDetails")
                        .HasForeignKey("WeatherDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeatherData");
                });

            modelBuilder.Entity("WeatherDOMAIN.Data.Models.City", b =>
                {
                    b.Navigation("WeatherDatas");
                });

            modelBuilder.Entity("WeatherDOMAIN.Data.Models.WeatherData", b =>
                {
                    b.Navigation("WeatherDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
