using Caliburn.Micro;
using iVM.Core.Entity;
using System.ComponentModel;

namespace iVM.Core.UI.ViewModels
{
  public class VehicleAddViewModelBase : BaseViewModel
  {

    protected VehicleTypeEntity _selectedVehicleType;
    public VehicleTypeEntity SelectedVehicleType
    {
      get { return this._selectedVehicleType; }
      set
      {
        this._selectedVehicleType = value;
        this.NotifyOfPropertyChange(() => this.SelectedVehicleType);
      }
    }

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

    protected VehicleBrandEntity _selectedVehicleBrand;
    public VehicleBrandEntity SelectedVehicleBrand
    {
      get { return this._selectedVehicleBrand; }
      set
      {
        this._selectedVehicleBrand = value;
        this.NotifyOfPropertyChange(() => this.SelectedVehicleBrand);
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

    private bool _isFirstStep;
    public bool IsFirstStep
    {
      get { return _isFirstStep; }
      set
      {
        _isFirstStep = value;
        this.NotifyOfPropertyChange(() => this.IsFirstStep);
      }
    }
    private bool _isSecondStep;
    public bool IsSecondStep
    {
      get { return _isSecondStep; }
      set
      {
        _isSecondStep = value;
        this.NotifyOfPropertyChange(() => this.IsSecondStep);
      }
    }

    protected override void viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.SelectedVehicleBrand):
          //this._navService.For<ShellViewModel>().Navigate();
          break;
        case nameof(this.SelectedVehicleType):
          this.IsFirstStep = false;
          this.IsSecondStep = true;
          break;
      }
    }

    private readonly IRepository<VehicleBrandEntity> vehicleRepository;
    public VehicleAddViewModelBase(
      IEventAggregator eventAggregator,
      IRepository<VehicleBrandEntity> vehicleRepository) : base(eventAggregator)
    {
      this.vehicleRepository = vehicleRepository;
    }

  }
}
