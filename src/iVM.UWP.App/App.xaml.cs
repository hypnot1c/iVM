using Caliburn.Micro;
using iVM.Core.Entity.Services;
using iVM.Data.Master.Context;
using iVM.Data.Vehicle.Context;
using iVM.UWP.App.Messages;
using iVM.UWP.App.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace iVM
{
  /// <summary>
  /// Provides application-specific behavior to supplement the default Application class.
  /// </summary>
  sealed partial class App
  {
    private WinRTContainer _container;
    private IEventAggregator _eventAggregator;

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>

    public App()
    {
      //WindowsAppInitializer.InitializeAsync();
      this.InitializeComponent();
      this.RequestedTheme = Windows.UI.Xaml.ApplicationTheme.Dark;
      //this.Suspending += OnSuspending;
    }

    protected override void Configure()
    {
      _container = new WinRTContainer();

      _container.RegisterWinRTServices();

      _container.Handler<VehicleContext>(sc =>
      {
        var optionsBuilder = new DbContextOptionsBuilder<VehicleContext>();
        optionsBuilder.UseInMemoryDatabase("vehicle");

        return new VehicleContext(optionsBuilder.Options);
      });

      _container.Handler<MasterContext>(sc =>
      {
        var optionsBuilder = new DbContextOptionsBuilder<MasterContext>();
        optionsBuilder.UseInMemoryDatabase("master");

        return new MasterContext(optionsBuilder.Options);
      });

      // Make sure to register your containers here
      _container
        //.Instance<IConfigurationService>(new ConfigurationService())
        .Singleton<UserSessionService>()
        .PerRequest<WelcomeViewModel>()
        .PerRequest<ShellViewModel>()
        .PerRequest<PivotViewModel>()
        .PerRequest<EventListViewModel>()
        .PerRequest<EventTypeSelectViewModel>()
        .PerRequest<FillUpAddViewModel>()
        ;


      this._eventAggregator = _container.GetInstance<IEventAggregator>();

      //var vehicleContext = _container.GetInstance<VehicleContext>();
      //vehicleContext.FillDummyData();
      //var mainContext = _container.GetInstance<MasterContext>();
      //mainContext.FillDummyData();
    }

    protected override void PrepareViewFirst(Frame rootFrame)
    {
      var navigationService = _container.RegisterNavigationService(rootFrame);
      var navigationManager = SystemNavigationManager.GetForCurrentView();

      navigationService.Navigated += (s, e) =>
      {
        navigationManager.AppViewBackButtonVisibility = navigationService.CanGoBack ?
                  AppViewBackButtonVisibility.Visible :
                  AppViewBackButtonVisibility.Collapsed;
      };
    }

    /// <summary> 
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>

    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      if (e.PreviousExecutionState == ApplicationExecutionState.Running)
        return;

      DisplayRootViewFor<WelcomeViewModel>();

      if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
      {
        _eventAggregator.PublishOnUIThread(new ResumeStateMessage());
      }
    }

    /// <summary>
    /// Invoked when application execution is being suspended.  Application state is saved
    /// without knowing whether the application will be terminated or resumed with the contents
    /// of memory still intact.
    /// </summary>

    /// <param name="sender">The source of the suspend request.</param>
    /// <param name="e">Details about the suspend request.</param>
    protected override void OnSuspending(object sender, SuspendingEventArgs e)
    {
      _eventAggregator.PublishOnUIThread(new SuspendStateMessage(e.SuspendingOperation));
    }

    protected override object GetInstance(Type service, string key)
    {
      return _container.GetInstance(service, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
      return _container.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
      _container.BuildUp(instance);
    }
  }
}
