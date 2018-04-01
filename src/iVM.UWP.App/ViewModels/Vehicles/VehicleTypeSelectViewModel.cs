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

      this.NavMenuItems = new List<NavMenuItem>
      {
        new NavMenuItem { Title = "Car", TargetViewModel = typeof(CarAddViewModel) }
      };
    }

    public List<NavMenuItem> NavMenuItems { get; set; }
    private NavMenuItem _selectedNavMenuItem;
    public NavMenuItem SelectedNavMenuItem
    {
      get { return this._selectedNavMenuItem; }
      set
      {
        this._selectedNavMenuItem = value;
        this.NotifyOfPropertyChange(() => this.SelectedNavMenuItem);
        this._navService.NavigateToViewModel(this._selectedNavMenuItem.TargetViewModel);
      }
    }
  }
}
