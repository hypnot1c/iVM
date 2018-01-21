using iVM.Core.Entity;
using iVM.Data.Master.Context;
using iVM.Data.Master.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iVM.Core.Entity.Services
{
  public static class EventExtensions
  {

    public static async Task FillUp_CreateAsync(this MasterContext context, FillUpEntity fillUp)
    {
      var fillUpModel = new FillUpModel();
      fillUpModel.LitresValue = fillUp.Litres;
      fillUpModel.LiterCost = fillUp.LiterCost;

      await context.FillUps.AddAsync(fillUpModel);
      await context.SaveChangesAsync();

      var @event = new EventOccuredModel();
      @event.Expense = fillUp.Expense;
      @event.Title = fillUp.Name;
      @event.Date = fillUp.OccuredDate;
      @event.Mileage = fillUp.Mileage;
      @event.EntityId = fillUpModel.Id;
      @event.Type = Data.Master.Model.EventType.FillUp;

      @event.Vehicle_VehicleId = fillUp.Vehicle.Id;

      await context.EventsOccured.AddAsync(@event);
      await context.SaveChangesAsync();
    }
  }
}
