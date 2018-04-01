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
      MasterContext masterContext,
      VehicleContext vehicleContext
      ) : base(eventAggregator, masterContext, vehicleContext)
    {
    }

    private string _brandName;
    public string BrandName
    {
      get { return this._brandName; }
      set { this._brandName = value; NotifyOfPropertyChange(() => this.BrandName); }
    }

    private string _modelName;
    public string ModelName
    {
      get { return this._modelName; }
      set { this._modelName = value; NotifyOfPropertyChange(() => this.ModelName); }
    }
  }
}
