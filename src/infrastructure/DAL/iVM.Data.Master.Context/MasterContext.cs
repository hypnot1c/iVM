using DataBaseContextExtensions;
using iVM.Data.Master.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace iVM.Data.Master.Context
{
  public class MasterContext : DbContext
  {
    public MasterContext(DbContextOptions<MasterContext> options) : base(options)
    {

    }
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
    //var serviceProvider = new ServiceCollection()
    //          .AddEntityFrameworkInMemoryDatabase()
    //          .BuildServiceProvider();

    //optionsBuilder.UseInMemoryDatabase()
    //  .UseInternalServiceProvider(serviceProvider);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.UseEntityTypeConfiguration(typeof(MasterContext).GetTypeInfo().Assembly);
    }

    public void FillDummyData()
    {
      // Add some data
      this.Add(new VehicleModel { Model_vehicleModelId = 1, Type_vehicleTypeId = 2, Mileage = 128000 });

      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 1, Title = "Gazpromneft", Date = DateTime.ParseExact("17.07.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1964.68M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 2, Title = "Gazpromneft", Date = DateTime.ParseExact("17.07.2016", "dd.MM.yyyy", null), Mileage = 186100, Expense = 1964.68M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 3, Title = "Gazpromneft", Date = DateTime.ParseExact("15.07.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1221M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 4, Title = "Gazpromneft", Date = DateTime.ParseExact("13.07.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1149M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 5, Title = "Gazpromneft", Date = DateTime.ParseExact("03.07.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1143M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 6, Title = "Gazpromneft", Date = DateTime.ParseExact("19.06.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1134M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 7, Title = "Gazpromneft", Date = DateTime.ParseExact("11.06.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1430.1M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 8, Title = "Gazpromneft", Date = DateTime.ParseExact("05.06.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 2153.49M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 9, Title = "Gazpromneft", Date = DateTime.ParseExact("28.05.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1128M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 10, Title = "Gazpromneft", Date = DateTime.ParseExact("15.05.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1137M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 11, Title = "Gazpromneft", Date = DateTime.ParseExact("08.05.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 2482.44M });
      this.Add(new EventOccuredModel { Vehicle_VehicleId = 1, Type = EventType.FillUp, EntityId = 12, Title = "Gazpromneft", Date = DateTime.ParseExact("03.05.2016", "dd.MM.yyyy", null), Mileage = 186000, Expense = 1191M });

      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 51.29M, LiterCost = 38.31M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 51.29M, LiterCost = 38.31M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 31.87M, LiterCost = 38.31M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 38.30M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 38.10M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 37.80M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 37.33M, LiterCost = 38.31M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 56.22M, LiterCost = 38.30M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 37.60M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 37.90M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 64.81M, LiterCost = 38.30M });
      this.Add(new FillUpModel { CompanyName = "Gazpromneft", LitresValue = 30.00M, LiterCost = 39.70M });

      this.SaveChanges();
    }

    public DbSet<VehicleModel> Vehicles { get; set; }
    public DbSet<EventOccuredModel> EventsOccured { get; set; }
    public DbSet<FillUpModel> FillUps { get; set; }
  }
}
