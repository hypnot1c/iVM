using Caliburn.Micro;
using iVM.Core.Entity.Services;
using iVM.Core.UI.ViewModels;

namespace iVM.UWP.App.ViewModels
{
  public class EventListViewModel : EventListViewModelBase
  {
    private readonly INavigationService _navService;

    public EventListViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      EventService eventService
      ) : base(eventAggregator, eventService)
    {
      this._navService = navigationService;
    }

    protected override void OnActivate()
    {
      _evAggregator.Subscribe(this);
    }

    protected override void OnDeactivate(bool close)
    {
      _evAggregator.Unsubscribe(this);
    }
    public void EventAdd()
    {
      _navService.For<EventTypeSelectViewModel>().Navigate();
    }
  }
}
