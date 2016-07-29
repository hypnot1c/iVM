using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.Entity.Services;
using iVM.Core.UI.ViewModels;
using System;

namespace iVM.UWP.App.ViewModels
{
  public class EventTypeSelectViewModel : EventTypeSelectViewModelBase
  {
    private readonly INavigationService _navService;

    public EventTypeSelectViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      EventService eventService) : base(eventAggregator, eventService)
    {
      this._navService = navigationService;
    }

    protected override void OnActivate()
    {
      base.OnActivate();
    }

    protected override void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
            case EventType.Maintenance:
              this._navService.For<MaintenanceAddViewModel>().Navigate();
              break;
          }
          break;
      }
    }
  }
}
