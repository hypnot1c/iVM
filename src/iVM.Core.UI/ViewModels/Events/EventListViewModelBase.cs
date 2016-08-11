using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.Entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iVM.Core.UI.ViewModels
{
  public class EventListViewModelBase : BaseViewModel
  {
    protected readonly EventService eventService;

    public EventListViewModelBase(
      IEventAggregator eventAggregator,
      EventService eventService
      ) : base(eventAggregator)
    {
      this.eventService = eventService;
      this.Events = this.eventService.GetOccuredEvents().OrderByDescending(e => e.OccuredDate).GroupBy(x => x.OccuredDate);
    }

    public IEnumerable<IGrouping<DateTime, EventOccuredEntity>> Events { get; set; }
  }
}
