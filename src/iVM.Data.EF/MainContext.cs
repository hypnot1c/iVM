using iVM.Data.Model;
using iVM.Vehicle.Data.EF.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace iVM.Data.EF
{
  public class MainContext : DbContext
  {

    public DbSet<VehicleModel> Vehicles { get; set; }
    public DbSet<EventOccured> EventsOccured { get; set; }

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
    }

    public void FillDummyData()
    {
      // Add some data
      this.Add(new VehicleModel { Id = 1, Model_vehicleModelId = 1, Type_vehicleTypeId = 2 });
      this.SaveChanges();
    }
  }
}
