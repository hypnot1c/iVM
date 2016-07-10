using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.Entity.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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

    private IEnumerable<VehicleTypeEntity> _vehicleTypes;
    public IEnumerable<VehicleTypeEntity> VehicleTypes
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

    private IEnumerable<VehicleBrandEntity> _vehicleBrands;
    public IEnumerable<VehicleBrandEntity> VehicleBrands
    {
      get { return this._vehicleBrands; }
      set
      {
        this._vehicleBrands = value;
        this.NotifyOfPropertyChange(() => this.VehicleBrands);

      }
    }

    protected VehicleBrandEntity _selectedVehicleModel;
    public VehicleBrandEntity SelectedVehicleModel
    {
      get { return this._selectedVehicleModel; }
      set
      {
        this._selectedVehicleModel = value;
        this.NotifyOfPropertyChange(() => this.SelectedVehicleModel);
      }
    }

    private IEnumerable<VehicleModelEntity> _vehicleModels;

    public IEnumerable<VehicleModelEntity> VehicleModels
    {
      get
      {
        if (this.SelectedVehicleBrand != null && this.SelectedVehicleType != null)
        {
          return this._vehicleModels.Where(m => m.BrandId == this.SelectedVehicleBrand.ID && m.vehicleTypeId == this.SelectedVehicleType.ID);
        }
        return this._vehicleModels;
      }
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

    private bool _isThirdStep;
    public bool IsThirdStep
    {
      get { return _isThirdStep; }
      set
      {
        _isThirdStep = value;
        this.NotifyOfPropertyChange(() => this.IsThirdStep);
      }
    }

    protected override void viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case nameof(this.SelectedVehicleBrand):
          this.IsSecondStep = false;
          this.IsThirdStep = true;
          break;
        case nameof(this.SelectedVehicleType):
          this.IsFirstStep = false;
          this.IsSecondStep = true;
          break;
      }
    }

    private readonly IVehicleService vehicleService;
    public VehicleAddViewModelBase(
      IEventAggregator eventAggregator,
      IVehicleService vehicleService) : base(eventAggregator)
    {
      this.vehicleService = vehicleService;
    }

  }
}
