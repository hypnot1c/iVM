using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.Entity.Services;
using System.Collections.Generic;

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
      this.Events = this.eventService.GetOccuredEvents();
    }

    public IEnumerable<EventEntity> Events { get; set; }
  }
}
