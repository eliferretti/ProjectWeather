﻿using Microsoft.EntityFrameworkCore;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Domain.ValueObjects;

namespace ProjectWeather.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cosmosUrl = "https://ferretticosmosdb.documents.azure.com:443/";
            var cosmosKey = "n3C2mBfqmzJS8Hf611t4I7lFippOlMDK8MZYkNqXDSbNdP2L3d3blYvUryJ8tCOSfA4fNiCfdM1GACDbLIej0Q==";

            optionsBuilder.UseCosmos(cosmosUrl, cosmosKey, databaseName: "db_weather");
        }
        
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Weather>().HasOne(w => w.Location).WithOne(l => l.Weather).HasForeignKey<Location>(l => l.WeatherId).OnDelete(DeleteBehavior.Cascade); 
            modelBuilder.Entity<Weather>().HasOne(w => w.Current).WithOne(c => c.Weather).HasForeignKey<Current>(c => c.WeatherId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Current>().HasOne(c => c.Condition).WithOne(c => c.Current).HasForeignKey<Condition>(c => c.CurrentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
