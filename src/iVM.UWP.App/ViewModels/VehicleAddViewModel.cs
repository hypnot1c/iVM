using Caliburn.Micro;
using iVM.Core.Entity.Services;
using iVM.Core.UI.ViewModels;

namespace iVM.UWP.App.ViewModels
{
  public class VehicleAddViewModel : VehicleAddViewModelBase
  {
    private readonly INavigationService _navService;

    public VehicleAddViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      VehicleService vehicleService) : base(eventAggregator, vehicleService)
    {
      this._navService = navigationService;
    }
  }
}
