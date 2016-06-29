using Caliburn.Micro;
using iVM.Core;
using iVM.Core.Entity;
using iVM.Core.UI.ViewModels;

namespace iVM.UWP.App.ViewModels
{
  public class VehicleAddViewModel : VehicleAddViewModelBase
  {
    public VehicleAddViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService, IRepository<VehicleBrandEntity> vehicleRepository) : base(eventAggregator, vehicleRepository)
    {
      this.VehicleTypes = new BindableCollection<VehicleTypeEntity>() { new VehicleTypeEntity() { Name = "Car" } };
      this.VehicleBrands = new BindableCollection<VehicleBrandEntity>();
      this.VehicleBrands.AddRange(vehicleRepository.GetAll());
    }
  }
}
