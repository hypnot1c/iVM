using iVM.Vehicle.Data.EF.ModelConfigurations;
using iVM.Vehicle.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace iVM.Vehicle.Data.EF
{
  public class VehicleContext: DbContext
  {
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<VehicleBrandModel> VehicleBrands { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //if (!optionsBuilder.IsConfigured)
      //{
      //  string databaseFilePath = "iVM.Vehicle.db";
      //  try
      //  {
      //    databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
      //  }
      //  catch (InvalidOperationException)
      //  { }

      //  optionsBuilder.UseSqlite($"Data source={dat abaseFilePath}");
      //}
      var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

      optionsBuilder.UseInMemoryDatabase()
        .UseInternalServiceProvider(serviceProvider);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<VehicleModel>(VehicleModelModelConfiguration.Configure);
      modelBuilder.Entity<VehicleBrandModel>(VehicleBrandModelConfiguration.Configure);
    }

    public void FillDummyData()
    {
      // Add Peugeot data
      this.Add(new VehicleBrandModel { Id = 1, Title = "Peugeot", VehicleTypes = new List<VehicleType> { VehicleType.Unknown, VehicleType.Car } });
      this.Add(new VehicleBrandModel { Id = 2, Title = "Volkswagen", VehicleTypes = new List<VehicleType> { VehicleType.Unknown, VehicleType.Car } });

      this.Add(new VehicleModel { Id = 1, BrandId = 1, Type = VehicleType.Car, Name = "406" });
      this.Add(new VehicleModel { Id = 2, BrandId = 2, Type = VehicleType.Car, Name = "Passat" });

      this.SaveChanges();
    }
  }
}
