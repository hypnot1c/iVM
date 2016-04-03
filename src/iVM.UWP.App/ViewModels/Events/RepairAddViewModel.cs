using Caliburn.Micro;
using FontAwesome.UWP;
using iVM.Core;
using iVM.Core.UI.ViewModels;
using iVM.Events;
using System;
using System.Collections.Generic;

namespace iVM.UWP.App.ViewModels
{
  public class RepairAddViewModel : RepairAddViewModelBase
  {
    private readonly IEventManager _eventManager;
    protected INavigationService _navigationService;

    public List<ActionButton> ActionButtons { get; private set; }

    private DateTimeOffset _dateOffset;
    public DateTimeOffset DateOffset
    {
      get { return this._dateOffset; }
      set
      {
        this._dateOffset = value;
        this.Date = DateOffset.DateTime;
      }
    }

    public RepairAddViewModel(IEventManager eventManager, IEventAggregator eventAggregator, INavigationService navigationService): base(eventAggregator)
    {
      this._eventManager = eventManager;
      this._navigationService = navigationService;
      this.ActionButtons = new List<ActionButton>
      {
        new ActionButton { Icon = FontAwesomeIcon.Save, OnClick = this.Save }
      };
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      this._evAggregator.PublishOnCurrentThread(new ViewActionButtonsEvent(this.ActionButtons));
    }

    protected override void Save()
    {
      this._evOccured.Name = "Ремонт";
      this._eventManager.RepairAdd(this._evOccured, this._repair);

      if (this._navigationService.CanGoBack)
        this._navigationService.GoBack();
      else
        this._navigationService.For<EventListViewModel>().Navigate();
      //throw new NotImplementedException();
    }
  }
}
