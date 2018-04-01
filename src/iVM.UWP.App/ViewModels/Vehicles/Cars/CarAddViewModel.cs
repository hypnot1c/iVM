using Caliburn.Micro;
using iVM.Core.UI.ViewModels.Vehicle;
using iVM.Data.Master.Context;
using iVM.Data.Vehicle.Context;

namespace iVM.UWP.App.ViewModels
{
  public class CarAddViewModel : CarAddViewModelBase
  {
    public CarAddViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      MasterContext masterContext,
      VehicleContext vehicleContext
      ) : base(eventAggregator, masterContext, vehicleContext)
    {
      this._navService = navigationService;
    }

    private readonly INavigationService _navService;

    protected override void Save()
    {
      base.Save();
      this._navService.NavigateToViewModel<ShellViewModel>();
    }
  }
}
