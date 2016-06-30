using Caliburn.Micro;
using iVM.Core;
using iVM.Core.Entity;
using iVM.Core.UI.ViewModels;

namespace iVM.UWP.App.ViewModels
{
  public class VehicleAddViewModel : VehicleAddViewModelBase
  {
    private readonly INavigationService _navService;

    public VehicleAddViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      IRepository<VehicleBrandEntity> vehicleRepository) : base(eventAggregator, vehicleRepository)
    {
      this._navService = navigationService;
      this.VehicleTypes = new BindableCollection<VehicleTypeEntity>() { new VehicleTypeEntity() { Name = "Car" } };
      this.VehicleBrands = new BindableCollection<VehicleBrandEntity>();
      this.VehicleBrands.AddRange(vehicleRepository.GetAll());
    }

    protected override void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.SelectedVehicleBrand) :
          //this._navService.For<ShellViewModel>().Navigate();
          break;
      }
    }
  }
}
