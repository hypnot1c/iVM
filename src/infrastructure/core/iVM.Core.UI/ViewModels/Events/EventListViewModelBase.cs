using Caliburn.Micro;
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
      this.Events = this.masterContext.EventsOccured.OrderByDescending(e => e.CorrectionDate).GroupBy(x => x.CorrectionDate);
      this.DisplayName = "Events";
    }

    private readonly MasterContext masterContext;

    public IEnumerable<IGrouping<DateTimeOffset, EventOccuredModel>> Events { get; set; }
  }
}
