using Caliburn.Micro;
using FontAwesome.UWP;
using iVM.Core;
using iVM.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iVM.ViewModels
{
  public class EventAddViewModel : Screen
  {
    private readonly IEventAggregator _eventAggregator;
    private readonly IEventManager _eventManager;
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
        return this._eventManager.EventTypes.Select(et => et.Name).ToList();
      }
    }

    public EventAddViewModel(IEventManager eventManager, IEventAggregator eventAggregator, INavigationService navigationService)
    {
      _eventManager = eventManager;
      _eventAggregator = eventAggregator;
      this._navigationService = navigationService;
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
      //var ev = new Model.EventOccured();
      //ev.Mileage = 180000;
      //ev.Name = "Заправка Газпром";
      //ev.EventTypeID = 1;
      //ev.Expense = 1000;
      //ev.Date = DateTime.Now;
      //ev.Description = "Очередная";
      //this._eventManager.EventOccuredAdd(ev);

      if (this._navigationService.CanGoBack)
        this._navigationService.GoBack();
      else
        this._navigationService.For<EventsViewModel>().Navigate();
      //throw new NotImplementedException();
    }
  }
}