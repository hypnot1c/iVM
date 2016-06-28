using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.UI.ViewModels;

namespace iVM.UWP.App.ViewModels
{
  public class VehicleAddViewModel : VehicleAddViewModelBase
  {
    public VehicleAddViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService) : base(eventAggregator)
    {
      this.VehicleTypes = new BindableCollection<VehicleTypeEntity>() { new VehicleTypeEntity() { Name = "Car" } };
    }
  }
}
