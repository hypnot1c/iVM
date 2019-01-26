using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.UI.ViewModels;
using iVM.Data.Master.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iVM.UWP.App.ViewModels
{
  public class EventTypeSelectViewModel : EventTypeSelectViewModelBase
  {
    private readonly INavigationService _navService;

    public EventTypeSelectViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      MasterContext masterContext
      ) : base(eventAggregator, masterContext)
    {
      this._navService = navigationService;
    }

    protected async override Task OnActivateAsync(CancellationToken cancellationToken)
    {
      await base.OnActivateAsync(cancellationToken);
    }

    protected override void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.SelectedEventType):
          var parsedType = (EventType)Enum.Parse(typeof(EventType), this.SelectedEventType);
          switch (parsedType)
          {
            case EventType.FillUp:
              this._navService.For<FillUpAddViewModel>().Navigate();
              break;
            //case EventType.Maintenance:
            //  this._navService.For<MaintenanceAddViewModel>().Navigate();
            //  break;
          }
          break;
      }
    }
  }
}
