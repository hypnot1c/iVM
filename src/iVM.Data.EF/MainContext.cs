using iVM.Data.Model;
using iVM.Vehicle.Data.EF.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace iVM.Data.EF
{
  public class MainContext : DbContext
  {

    public DbSet<VehicleModel> Vehicles { get; set; }
    public DbSet<EventOccuredModel> EventsOccured { get; set; }
    public DbSet<FillUpModel> FillUps { get; set; }
    public DbSet<MaintenanceModel> Maintenances { get; set; }

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
      modelBuilder.Entity<EventOccuredModel>(EventOccuredModelConfiguration.Configure);
    }

    public void FillDummyData()
    {
      // Add some data
      this.Add(new VehicleModel { Model_vehicleModelId = 1, Type_vehicleTypeId = 2 });

      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("17.07.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1964.68M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("15.07.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1221M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("13.07.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1149M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("03.07.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1143M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("19.06.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1134M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("11.06.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1430.1M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("05.06.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 2153.49M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("28.05.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1128M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("15.05.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1137M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("08.05.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 2482.44M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("03.05.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1191M });

      this.Add(new FillUpModel { EventOccuredId = 1, CompanyName = "Gazpromneft", LitresValue = 51.29M, LiterCost = 38.31M });
      this.Add(new FillUpModel { EventOccuredId = 2, CompanyName = "Gazpromneft", LitresValue = 31.87M, LiterCost = 38.31M });
      this.Add(new FillUpModel { EventOccuredId = 3, CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 38.30M });
      this.Add(new FillUpModel { EventOccuredId = 4, CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 38.10M });
      this.Add(new FillUpModel { EventOccuredId = 5, CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 37.80M });
      this.Add(new FillUpModel { EventOccuredId = 6, CompanyName = "Gazpromneft", LitresValue = 37.33M, LiterCost = 38.31M });
      this.Add(new FillUpModel { EventOccuredId = 7, CompanyName = "Gazpromneft", LitresValue = 56.22M, LiterCost = 38.30M });
      this.Add(new FillUpModel { EventOccuredId = 8, CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 37.60M });
      this.Add(new FillUpModel { EventOccuredId = 9, CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 37.90M });
      this.Add(new FillUpModel { EventOccuredId = 10, CompanyName = "Gazpromneft", LitresValue = 64.81M, LiterCost = 38.30M });
      this.Add(new FillUpModel { EventOccuredId = 11, CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 39.70M });

      this.SaveChanges();
    }
  }
}
