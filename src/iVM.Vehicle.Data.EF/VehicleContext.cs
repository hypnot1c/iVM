using iVM.Vehicle.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //  modelBuilder.Entity<VehicleModel>(VehicleModelModelConfiguration.Configure);
    //}
  }
}
