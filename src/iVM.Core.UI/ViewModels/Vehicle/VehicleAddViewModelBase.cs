using Caliburn.Micro;

namespace iVM.Core.UI.ViewModels
{
  public class VehicleAddViewModelBase : BaseViewModel
  {
    private IObservableCollection<VehicleType> _vehicleTypes;
    public IObservableCollection<VehicleType> VehicleTypes
    {
      get { return this._vehicleTypes; }
      set
      {
        this._vehicleTypes = value;
        this.NotifyOfPropertyChange(() => this.VehicleTypes);
      }
    }
    public VehicleAddViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }
  }
}
