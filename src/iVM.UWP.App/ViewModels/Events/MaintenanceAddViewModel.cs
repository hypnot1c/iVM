using Caliburn.Micro;
using iVM.Core.Entity.Services;
using iVM.Core.UI.ViewModels;
using System;

namespace iVM.UWP.App.ViewModels
{
  public class MaintenanceAddViewModel : MaintenanceAddViewModelBase
  {
    protected INavigationService _navigationService;

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

    public MaintenanceAddViewModel(
      IEventAggregator eventAggregator, 
      INavigationService navigationService,
      EventService eventService
      ): base(eventAggregator, eventService)
    {
      this._navigationService = navigationService;
      this.DateOffset = DateTimeOffset.Now;
    }

    protected override void Save()
    {
      this._navigationService.For<EventListViewModel>().Navigate();
    }
  }
}
