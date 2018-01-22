using Caliburn.Micro;
using iVM.Core.UI.ViewModels.Vehicle;
using iVM.Data.Vehicle.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.UWP.App.ViewModels
{
  public class VehicleTypeSelectViewModel : VehicleTypeSelectViewModelBase
  {
    protected INavigationService _navService;

    public VehicleTypeSelectViewModel(
      INavigationService navigationService,
      IEventAggregator eventAggregator, 
      VehicleContext masterContext
      ) : base(eventAggregator, masterContext)
    {
      this._navService = navigationService;
    }
  }
}
