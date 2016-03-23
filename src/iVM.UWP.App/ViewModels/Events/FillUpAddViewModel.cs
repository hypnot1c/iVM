using Caliburn.Micro;
using FontAwesome.UWP;
using iVM.Core;
using iVM.Core.UI.ViewModels;
using iVM.Events;
using System.Collections.Generic;

namespace iVM.UWP.App.ViewModels
{
  public class FillUpAddViewModel : FillUpAddViewModelBase
  {
    private readonly IEventManager _eventManager;
    protected INavigationService _navigationService;

    public List<ActionButton> ActionButtons { get; private set; }

    public FillUpAddViewModel(IEventManager eventManager, IEventAggregator eventAggregator, INavigationService navigationService): base(eventAggregator)
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