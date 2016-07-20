using Caliburn.Micro;
using FontAwesome.UWP;
using iVM.Core.UI.ViewModels;
using iVM.Events;
using System.Collections.Generic;

namespace iVM.UWP.App.ViewModels
{
  public class EventListViewModel : EventListViewModelBase
  {
    private readonly INavigationService _navService;

    public List<ActionButton> ActionButtons { get; private set; }

    public EventListViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService) : base(eventAggregator)
    {
      this._navService = navigationService;
      this.ActionButtons = new List<ActionButton>
      {
        new ActionButton() { Icon = FontAwesomeIcon.CheckSquareOutline, OnClick = this.EventAdd },
        new ActionButton() { Icon = FontAwesomeIcon.PlusSquare, OnClick = this.EventAdd }
      };
    }

    protected override void OnActivate()
    {
      _evAggregator.PublishOnCurrentThread(new ViewActionButtonsEvent(this.ActionButtons));
      _evAggregator.Subscribe(this);
    }

    protected override void OnDeactivate(bool close)
    {
      _evAggregator.Unsubscribe(this);
    }
    public void EventAdd()
    {
      //_navService.For<EventTypeListViewModel>().Navigate();
    }
  }
}
