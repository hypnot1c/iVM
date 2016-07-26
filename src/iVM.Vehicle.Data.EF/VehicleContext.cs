using iVM.Vehicle.Data.EF.ModelConfigurations;
using iVM.Vehicle.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace iVM.Vehicle.Data.EF
{
  public class VehicleContext: DbContext
  {
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<VehicleBrandModel> VehicleBrands { get; set; }

    public DbSet<VehicleTypeModel> VehicleTypes { get; set; }
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
      modelBuilder.Entity<VehicleModel>(VehicleModelConfiguration.Configure);
      modelBuilder.Entity<VehicleBrandModel>(VehicleBrandModelConfiguration.Configure);
      modelBuilder.Entity<VehicleTypeModel>(VehicleTypeModelConfiguration.Configure);
      modelBuilder.Entity<VehicleBrandAndTypeModel>(VehicleBrandAndTypeModelConfiguration.Configure);
    }

    public void FillDummyData()
    {
      // Add Peugeot data
      this.Add(new VehicleTypeModel { Id = 1, Name = "Unknown" });
      this.Add(new VehicleTypeModel { Id = 2, Name = "Car" });

      this.Add(new VehicleBrandModel { Id = 1, Title = "Peugeot" });
      this.Add(new VehicleBrandModel { Id = 2, Title = "Volkswagen" });

      this.Add(new VehicleBrandAndTypeModel { BrandId = 1, TypeId = 2 });
      this.Add(new VehicleBrandAndTypeModel { BrandId = 2, TypeId = 2 });

      this.Add(new VehicleModel { Id = 1, Brand_BrandId = 1, Type_TypeId = 2, Name = "406" });
      this.Add(new VehicleModel { Id = 2, Brand_BrandId = 2, Type_TypeId = 2, Name = "Passat" });

      this.SaveChanges();
    }
  }
}
