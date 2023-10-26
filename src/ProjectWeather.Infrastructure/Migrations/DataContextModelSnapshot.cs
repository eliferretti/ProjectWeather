﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectWeather.Infrastructure.Data;

#nullable disable

namespace ProjectWeather.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("ProjectWeather.Domain.Entities.Weather", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("ProjectWeather.Domain.ValueObjects.Condition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrentId")
                        .IsUnique();

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("ProjectWeather.Domain.ValueObjects.Current", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cloud")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Feelslike_c")
                        .HasColumnType("REAL");

                    b.Property<float>("Feelslike_f")
                        .HasColumnType("REAL");

                    b.Property<float>("Gust_kph")
                        .HasColumnType("REAL");

                    b.Property<float>("Gust_mph")
                        .HasColumnType("REAL");

                    b.Property<int>("Humidity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Is_day")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Last_updated")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Last_updated_epoch")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Precip_in")
                        .HasColumnType("REAL");

                    b.Property<float>("Precip_mm")
                        .HasColumnType("REAL");

                    b.Property<float>("Pressure_in")
                        .HasColumnType("REAL");

                    b.Property<float>("Pressure_mb")
                        .HasColumnType("REAL");

                    b.Property<float>("Temp_c")
                        .HasColumnType("REAL");

                    b.Property<float>("Temp_f")
                        .HasColumnType("REAL");

                    b.Property<float>("Uv")
                        .HasColumnType("REAL");

                    b.Property<float>("Vis_km")
                        .HasColumnType("REAL");

                    b.Property<float>("Vis_miles")
                        .HasColumnType("REAL");

                    b.Property<string>("WeatherId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Wind_degree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Wind_dir")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Wind_kph")
                        .HasColumnType("REAL");

                    b.Property<float>("Wind_mph")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("WeatherId")
                        .IsUnique();

                    b.ToTable("Currents");
                });

            modelBuilder.Entity("ProjectWeather.Domain.ValueObjects.Location", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Lat")
                        .HasColumnType("REAL");

                    b.Property<string>("Localtime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Localtime_epoch")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Lon")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tz_id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WeatherId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WeatherId")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ProjectWeather.Domain.ValueObjects.Condition", b =>
                {
                    b.HasOne("ProjectWeather.Domain.ValueObjects.Current", "Current")
                        .WithOne("Condition")
                        .HasForeignKey("ProjectWeather.Domain.ValueObjects.Condition", "CurrentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Current");
                });

            modelBuilder.Entity("ProjectWeather.Domain.ValueObjects.Current", b =>
                {
                    b.HasOne("ProjectWeather.Domain.Entities.Weather", "Weather")
                        .WithOne("Current")
                        .HasForeignKey("ProjectWeather.Domain.ValueObjects.Current", "WeatherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Weather");
                });

            modelBuilder.Entity("ProjectWeather.Domain.ValueObjects.Location", b =>
                {
                    b.HasOne("ProjectWeather.Domain.Entities.Weather", "Weather")
                        .WithOne("Location")
                        .HasForeignKey("ProjectWeather.Domain.ValueObjects.Location", "WeatherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Weather");
                });

            modelBuilder.Entity("ProjectWeather.Domain.Entities.Weather", b =>
                {
                    b.Navigation("Current")
                        .IsRequired();

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectWeather.Domain.ValueObjects.Current", b =>
                {
                    b.Navigation("Condition")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
