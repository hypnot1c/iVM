using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Data.Master.Context;
using iVM.Data.Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iVM.Core.UI.ViewModels
{
  public class EventListViewModelBase : BaseViewModel
  {

    public EventListViewModelBase(
      IEventAggregator eventAggregator,
      MasterContext masterContext
      ) : base(eventAggregator)
    {
      this.masterContext = masterContext;
      var eventsOccured = this.masterContext.EventsOccured.OrderByDescending(e => e.Date).Take(20).ToList();

      this.Events = eventsOccured.GroupBy(eo => eo.Date, eo => {
        switch(eo.Type)
        {
          case Data.Master.Model.EventType.FillUp:
            var evModel = this.masterContext.FillUps.Find(eo.EntityId);
            var fillUp = new FillUpEntity()
            {
              Id = evModel.Id,
              Name = eo.Title,
              Expense = eo.Expense,
              Profit = eo.Profit,
              LiterCost = evModel.LiterCost,
              Litres = evModel.LitresValue,
              Mileage = eo.Mileage,
              OccuredDate = eo.Date
            };
            return fillUp;
          default:
            return new EventOccuredEntity();
        }
      });
      this.DisplayName = "Events";
    }

    private readonly MasterContext masterContext;

    public IEnumerable<IGrouping<DateTime, EventOccuredEntity>> Events { get; set; }
  }
}
