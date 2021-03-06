﻿using iVM.Core.Entity.Services;
using iVM.Data.EF;
using System;

namespace iVM.UWP.Entity.Services
{
  public class MainUnitOfWork : IMainUnitOfWork
  {
    private readonly MainContext _context;

    public MainUnitOfWork(MainContext context)
    {
      this._context = context;
    }

    private IEventOccuredRepository _eventsOccured;
    public IEventOccuredRepository EventsOccured
    {
      get
      {
        if(this._eventsOccured == null)
        {
          this._eventsOccured = new EventOccuredRepository(this._context);
        }
        return this._eventsOccured;
      }
    }

    private IFillUpRepository _fillUps;
    public IFillUpRepository FillUps
    {
      get
      {
        if (this._fillUps == null)
        {
          this._fillUps = new FillUpRepository(this._context);
        }
        return this._fillUps;
      }
    }

    private IVehicleRepository _vehicles;
    public IVehicleRepository Vehicles
    {
      get
      {
        if (this._vehicles == null)
        {
          this._vehicles = new VehicleRepository(this._context);
        }
        return this._vehicles;
      }
    }

    private IMaintenanceRepository _maintenances;
    public IMaintenanceRepository Maintenances
    {
      get
      {
        if(this._maintenances == null)
        {
          this._maintenances = new MaintenanceRepository(this._context);
        }
        return _maintenances;
      }
    }

    private IMaintenanceItemRepository _maintenanceItems;
    public IMaintenanceItemRepository MaintenanceItems
    {
      get
      {
        if (this._maintenanceItems == null)
        {
          this._maintenanceItems = new MaintenanceItemRepository(this._context);
        }
        return _maintenanceItems;
      }
    }

    public void Commit()
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public void Rollback()
    {
      throw new NotImplementedException();
    }

    public void Save()
    {
      this._context.SaveChanges();
    }
  }
}
