using Caliburn.Micro;
using FontAwesome.UWP;
using iVM.Events;
using System.Collections.Generic;

namespace iVM.ViewModels
{
  public class EventsViewModel: Screen
  {
    private readonly WinRTContainer _container;
    private readonly IEventAggregator _eventAggregator;
    protected INavigationService _navigationService;

    public List<ActionButton> ActionButtons { get; private set; }

    public EventsViewModel(WinRTContainer container, IEventAggregator eventAggregator, INavigationService navigationService)
    {
      _container = container;
      _eventAggregator = eventAggregator;
      this._navigationService = navigationService;
      this.ActionButtons = new List<ActionButton>
      {
        new ActionButton() { Icon = FontAwesomeIcon.CheckSquareOutline, OnClick = this.EventAdd },
        new ActionButton() { Icon = FontAwesomeIcon.PlusSquare, OnClick = this.EventAdd }
      };
    }

    protected override void OnActivate()
    {
      _eventAggregator.PublishOnCurrentThread(new ViewActionButtonsEvent(this.ActionButtons));
      _eventAggregator.Subscribe(this);
    }

    protected override void OnDeactivate(bool close)
    {
      _eventAggregator.Unsubscribe(this);
    }
    public void EventAdd()
    {
      _navigationService.For<EventAddViewModel>().Navigate();
    }
  }
}
