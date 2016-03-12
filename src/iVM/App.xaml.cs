using Caliburn.Micro;
using iVM.Data.SQLdatabase;
using iVM.ViewModels;
using Microsoft.ApplicationInsights;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
      using (var db = new MainContext())
      {
        db.Database.Migrate();
      }

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
                .PerRequest<ShellViewModel>()
                .PerRequest<EventsViewModel>()
                .PerRequest<EventAddViewModel>();

      _eventAggregator = _container.GetInstance<IEventAggregator>();
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

      //if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
      //{
      //  _eventAggregator.PublishOnUIThread(new ResumeStateMessage());
      //}
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
