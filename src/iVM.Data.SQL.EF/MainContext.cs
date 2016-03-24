﻿using iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations;
using iVM.Model;
using Microsoft.Data.Entity;
using System;
using System.IO;
using Windows.Storage;

namespace iVM.Data.SQL.EF.SQLdatabase
{
  public class MainContext : DbContext
  {

    public DbSet<EventType> EventTypes { get; set; }

    public DbSet<EventOccured> EventsOccured { get; set; }

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
      modelBuilder.Entity<FillUp>(FillUpModelConfiguration.Configure);
    }
  }
}