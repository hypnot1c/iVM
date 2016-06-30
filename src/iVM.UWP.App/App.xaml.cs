using Caliburn.Micro;
using iVM.Core;
using iVM.Core.Entity;
using iVM.UWP.App.ViewModels;
using iVM.UWP.Entity.Services;
using iVM.Vehicle.Data.EF;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;

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
      //this.Suspending += OnSuspending;
    }

    protected override void Configure()
    {
      _container = new WinRTContainer();
      
      _container.RegisterWinRTServices();

      // Make sure to register your containers here
      _container
        .Singleton<VehicleContext, VehicleContext>()
        .PerRequest<IRepository<VehicleBrandEntity>, VehicleBrandRepository>()
        .PerRequest<ShellViewModel>()
        .PerRequest<VehicleAddViewModel>();

      this._eventAggregator = _container.GetInstance<IEventAggregator>();

      var vehicleContext = _container.GetInstance<VehicleContext>();
      vehicleContext.FillDummyData();
    }

    /// <summary> 
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>

    /// <param name="e">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      // I am launching my main view here
      DisplayRootViewFor<ShellViewModel>();
      //SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
      if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
      {
        _eventAggregator.PublishOnUIThread("ResumeMessage");
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
      //var deferral = e.SuspendingOperation.GetDeferral();
      //TODO: Save application state and stop any background activity
      //deferral.Complete();
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
