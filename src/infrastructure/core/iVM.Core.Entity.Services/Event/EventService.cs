﻿using iVM.Data.Model;
using System.Collections.Generic;

namespace iVM.Core.Entity.Services
{
  public class EventService
  {
    private readonly IMainUnitOfWork _mainUoW;
    private readonly IVehicleUnitOfWork _vehicleUoW;

    public EventService(
      IVehicleUnitOfWork vehicleUoW,
      IMainUnitOfWork mainUoW
      )
    {
      this._vehicleUoW = vehicleUoW;
      this._mainUoW = mainUoW;
    }

    #region Generic events
    public IEnumerable<EventOccuredEntity> GetOccuredEvents()
    {
      var events = new List<EventOccuredEntity>();
      var fillUps = this._mainUoW.FillUps.GetAll();
      var maintenances = this._mainUoW.Maintenances.GetAll();
      foreach (var fu in fillUps)
      {
        var ev = this._mainUoW.EventsOccured.Get(fu.EventOccuredId);
        var elm = new FillUpEntity
        {
          OccuredDate = ev.Date,
          Expense = ev.Expense,
          Litres = fu.LitresValue,
          Name = ev.Title
        };
        events.Add(elm);
      }

      foreach (var maint in maintenances)
      {
        var ev = this._mainUoW.EventsOccured.Get(maint.EventOccuredId);
        var elm = new MaintenanceEntity
        {
          OccuredDate = ev.Date,
          Expense = ev.Expense,
          ServiceStationName = maint.ServiceStationName,
          Name = ev.Title
        };
        events.Add(elm);
      }

      return events;
    }
    #endregion

    #region Fill ups
    public void AddFillUp(FillUpEntity fillUp)
    {
      var eo = new EventOccuredModel
      {
        Date = fillUp.OccuredDate,
        Title = fillUp.Name,
        Expense = fillUp.Expense,
        Profit = fillUp.Profit,
        Mileage = fillUp.Mileage
      };
      this._mainUoW.EventsOccured.Add(eo);
      this._mainUoW.Save();
      var fu = new FillUpModel
      {
        Id = fillUp.Id,
        EventOccuredId = eo.Id,
        LiterCost = fillUp.LiterCost,
        LitresValue = fillUp.Litres
      };
      this._mainUoW.FillUps.Add(fu);
      this._mainUoW.Save();
    }
    #endregion

    #region Maintenances
    public void AddMaintenance(MaintenanceEntity maintenance)
    {
      var ev = new EventOccuredModel
      {
        Vehicle_VehicleId = maintenance.Vehicle.Id,
        Title = maintenance.Name,
        Date = maintenance.OccuredDate,
        Expense = maintenance.Expense,
        Mileage = maintenance.Mileage
      };
      this._mainUoW.EventsOccured.Add(ev);
      this._mainUoW.Save();
      var maint = new MaintenanceModel
      {
        EventOccuredId = ev.Id,
        ServiceStationName = maintenance.ServiceStationName
      };
      this._mainUoW.Maintenances.Add(maint);
      foreach(var item in maintenance.ListOfWorks)
      {
        var workItem = new MaintenanceItemModel
        {
          MaintenanceId = maint.Id,
          Title = item.Title,
          PartsCost = item.PartCost,
          WorkCost = item.WorkCost
        };
        this._mainUoW.MaintenanceItems.Add(workItem);
      }
      this._mainUoW.Save();
    }
    #endregion
  }
}