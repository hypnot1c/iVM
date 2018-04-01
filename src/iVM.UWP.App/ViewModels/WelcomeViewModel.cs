using Caliburn.Micro;
using iVM.Core.Entity.Services;
using iVM.UWP.App.Views;

namespace iVM.UWP.App.ViewModels
{
  public class WelcomeViewModel : Screen
  {

    public WelcomeViewModel(
      INavigationService navigationService,
      UserSessionService userSessionService
      )
    {
      this.navigationService = navigationService;
      this.userSessionService = userSessionService;
    }

    private readonly INavigationService navigationService;
    private readonly UserSessionService userSessionService;

    public void DetectView()
    {
      if (!this.userSessionService.IsFirstLaunch)
      {
        this.navigationService.NavigateToViewModel<ShellViewModel>();
      }
    }

    public void AddNewVehicle()
    {
      this.navigationService.Navigate<VehicleTypeSelectView>();
    }
  }
}
