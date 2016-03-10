using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using System.IO;
using Windows.Storage;
using iVM.Model;
using iVM.Data.SQLdatabase.ModelConfigurations;

namespace iVM.Data.SQLdatabase
{
  public class MainContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string databaseFilePath = "iVM.db";
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
      modelBuilder.Entity<User>(UserModelConfiguration.Configure);
      modelBuilder.Entity<EventType>(EventTypeModelConfiguration.Configure);
      modelBuilder.Entity<EventOccured>(EventOccuredModelConfiguration.Configure);
    }
  }
}
