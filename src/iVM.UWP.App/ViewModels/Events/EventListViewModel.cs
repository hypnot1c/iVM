using Caliburn.Micro;
using iVM.Core.UI.ViewModels;
using iVM.Data.Master.Context;

namespace iVM.UWP.App.ViewModels
{
  public class EventListViewModel : EventListViewModelBase
  {
    private readonly INavigationService _navService;

    public EventListViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      MasterContext masterContext
      ) : base(eventAggregator, masterContext)
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
