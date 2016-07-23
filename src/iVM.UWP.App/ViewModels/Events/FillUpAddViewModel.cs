using Caliburn.Micro;
using iVM.Core.UI.ViewModels;
using System;

namespace iVM.UWP.App.ViewModels
{
  public class FillUpAddViewModel : FillUpAddViewModelBase
  {
    protected INavigationService _navigationService;

    private DateTimeOffset _dateOffset;
    public DateTimeOffset DateOffset {
      get { return this._dateOffset; }
      set
      {
        this._dateOffset = value;
        this.Date = DateOffset.DateTime;
      }
    }

    public FillUpAddViewModel(
      IEventAggregator eventAggregator, 
      INavigationService navigationService): base(eventAggregator)
    {
      this._navigationService = navigationService;
    }

    protected override void OnActivate()
    {
      base.OnActivate();
    }

    protected override void Save()
    {
      base.Save();
      //if (this._navigationService.CanGoBack)
      //  this._navigationService.GoBack();
      //else
      this._navigationService.For<EventListViewModel>().Navigate();
      //throw new NotImplementedException();
    }
  }
}