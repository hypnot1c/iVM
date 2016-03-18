using Caliburn.Micro;
using FontAwesome.UWP;
using iVM.Data;
using iVM.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iVM.ViewModels
{
  public class EventAddViewModel : Screen
  {
    private readonly WinRTContainer _container;
    private readonly IEventAggregator _eventAggregator;
    private readonly IDataRepository _dbRepository;
    protected INavigationService _navigationService;

    private bool _isFillUp;
    public bool IsFillUp
    {
      get
      {
        return this._isFillUp;
      }
      set
      {
        this._isFillUp = value;
        this.NotifyOfPropertyChange(() => this.IsFillUp);
      }
    }
    public List<ActionButton> ActionButtons { get; private set; }

    public List<string> lstType
    {
      get
      {
        return this._dbRepository.EventTypes.Select(et => et.Name).ToList();
      }
    }

    public EventAddViewModel(WinRTContainer container, IEventAggregator eventAggregator, INavigationService navigationService, IDataRepository dbRepository)
    {
      _container = container;
      _eventAggregator = eventAggregator;
      this._navigationService = navigationService;
      this._dbRepository = dbRepository;
      this.ActionButtons = new List<ActionButton>
      {
        new ActionButton { Icon = FontAwesomeIcon.Save, OnClick = this.Save }
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

    protected void onEventType_selectionChange(object source)
    {
      var eventType = source as string;
      eventType = String.IsNullOrEmpty(eventType) ? String.Empty : eventType.ToLower();
      this.IsFillUp = eventType == "fillup";
    }

    private void Save()
    {
      // this._dbRepository.Events.Add();
      if (this._navigationService.CanGoBack)
        this._navigationService.GoBack();
      else
        this._navigationService.For<EventsViewModel>().Navigate();
      //throw new NotImplementedException();
    }
  }
}