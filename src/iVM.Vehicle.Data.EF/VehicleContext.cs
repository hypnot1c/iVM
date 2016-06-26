using iVM.Vehicle.Data.EF.ModelConfigurations;
using iVM.Vehicle.Model;
using Microsoft.Data.Entity;
using System;
using System.IO;
using Windows.Storage;

namespace iVM.Vehicle.Data.EF
{
  public class VehicleContext: DbContext
  {
    public DbSet<VehicleModel> VehicleModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string databaseFilePath = "iVM.Vehicle.db";
      try
      {
        databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
      }
      catch (InvalidOperationException)
      { }

      optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<VehicleModel>(VehicleModelModelConfiguration.Configure);
    }
  }
}
