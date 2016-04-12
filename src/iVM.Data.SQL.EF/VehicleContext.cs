using iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations;
using iVM.Vehicle.Model;
using Microsoft.Data.Entity;
using System;
using System.IO;
using Windows.Storage;

namespace iVM.Data.SQL.EF
{
  public class VehicleContext: DbContext
  {
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<iVM.Vehicle.Model.Model> Models { get; set; }
    public DbSet<Vehicle.Model.Type> Types { get; set; }

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
      modelBuilder.Entity<Brand>(BrandModelConfiguration.Configure);
      modelBuilder.Entity<Category>(CategoryModelConfiguration.Configure);
      modelBuilder.Entity<iVM.Vehicle.Model.Model>(ModelModelConfiguration.Configure);
      modelBuilder.Entity<Vehicle.Model.Type>(TypeModelConfiguration.Configure);
      modelBuilder.Entity<CategoryToType>(CategoryToTypeModelConfiguration.Configure);
    }
  }
}
