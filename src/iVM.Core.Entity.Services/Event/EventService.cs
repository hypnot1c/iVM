using iVM.Data.Model;
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

    public void AddFillUp(FillUpEntity fillUp)
    {
      var eo = new EventOccured
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

    public IEnumerable<EventEntity> GetOccuredEvents()
    {
      var events = new List<EventEntity>();
      var fillUps = this._mainUoW.FillUps.GetAll();
      foreach (var fu in fillUps)
      {
        var ev = this._mainUoW.EventsOccured.Get(fu.EventOccuredId);
        var elm = new FillUpEntity
        {
          OccuredDate = ev.Date,
          Name = ev.Title
        };
        events.Add(elm);
      }
      return events;
    }
  }
}
