using Caliburn.Micro;
using iVM.Core.Entity;

namespace iVM.Core.UI.ViewModels
{
  public class VehicleAddViewModelBase : BaseViewModel
  {
    private IObservableCollection<VehicleTypeEntity> _vehicleTypes;
    public IObservableCollection<VehicleTypeEntity> VehicleTypes
    {
      get { return this._vehicleTypes; }
      set
      {
        this._vehicleTypes = value;
        this.NotifyOfPropertyChange(() => this.VehicleTypes);
      }
    }

    private IObservableCollection<VehicleBrandEntity> _vehicleBrands;
    public IObservableCollection<VehicleBrandEntity> VehicleBrands
    {
      get { return this._vehicleBrands; }
      set
      {
        this._vehicleBrands = value;
        this.NotifyOfPropertyChange(() => this.VehicleBrands);
      }
    }

    private IObservableCollection<VehicleModelEntity> _vehicleModels;
    public IObservableCollection<VehicleModelEntity> VehicleModels
    {
      get { return this._vehicleModels; }
      set
      {
        this._vehicleModels = value;
        this.NotifyOfPropertyChange(() => this.VehicleModels);
      }
    }

    public VehicleModelEntity vehicleModel { get; set; }


    public VehicleAddViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }
  }
}
