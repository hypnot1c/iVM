using Caliburn.Micro;
using iVM.Core.Entity.Services;
using iVM.UWP.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.UWP.App.ViewModels
{
  public class WelcomeViewModel : Screen
  {

    public WelcomeViewModel(INavigationService navigationService, UserSessionService userSessionService)
    {
      this.navigationService = navigationService;

      if(!userSessionService.IsFirstLaunch)
      {
        this.navigationService.NavigateToViewModel<ShellViewModel>();
      }
    }

    private readonly INavigationService navigationService;

    public void AddNewVehicle()
    {
      this.navigationService.Navigate<VehicleTypeSelectView>();
    }
  }
}
