using Caliburn.Micro;
using iVM.Core.Entity.Services;
using iVM.Core.UI.ViewModels;
using iVM.Data.Master.Context;
using System;

namespace iVM.UWP.App.ViewModels
{
  public class FillUpAddViewModel : FillUpAddViewModelBase
  {
    protected INavigationService _navService;

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

    public FillUpAddViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      UserSessionService userSessionService,
      MasterContext masterContext
      ) : base(eventAggregator, userSessionService, masterContext)
    {
      this._navService = navigationService;
      this.DateOffset = DateTimeOffset.Now;
    }

    protected override void Save()
    {
      base.Save();
      if (this._navService.CanGoBack)
      {
        this._navService.GoBack();
      }
      else
      {
        this._navService.For<EventListViewModel>().Navigate();
      }
    }

    public void Cancel()
    {
      if (this._navService.CanGoBack)
      {
        this._navService.GoBack();
      }
      else
      {
        this._navService.For<EventListViewModel>().Navigate();
      }
    }
  }
}