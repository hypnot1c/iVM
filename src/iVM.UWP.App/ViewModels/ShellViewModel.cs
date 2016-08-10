using Caliburn.Micro;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace iVM.UWP.App.ViewModels
{
  public class ShellViewModel : Screen
  {
    private readonly WinRTContainer _container;
    private readonly IEventAggregator _eventAggregator;
    protected INavigationService _navigationService;

    private int _collapsedPanelLength;

    public int CollapsedPanelLength
    {
      get { return _collapsedPanelLength; }
      set
      {
        _collapsedPanelLength = value;
        this.NotifyOfPropertyChange(() => this.CollapsedPanelLength);
      }
    }

    private bool _isNotFirstVisit;
    public bool IsNotFirstVisit
    {
      get { return this._isNotFirstVisit; }
      set
      {
        this._isNotFirstVisit = value;
        this.NotifyOfPropertyChange(() => this.IsNotFirstVisit);
      }
    }

    public IEnumerable<NavMenuItem> NavMenuItems { get; set; }

    private NavMenuItem _selectedNavMenuItem;
    public NavMenuItem SelectedNavMenuItem {
      get { return this._selectedNavMenuItem; }
      set
      {
        this._selectedNavMenuItem = value;
        this.NotifyOfPropertyChange(() => this.SelectedNavMenuItem);
      }
    }
    public ShellViewModel(WinRTContainer container, IEventAggregator eventAggregator)
    {
      this.PropertyChanged += ShellViewModel_PropertyChanged;
      this._container = container;
      this._eventAggregator = eventAggregator;
      this.CollapsedPanelLength = 0;
      this.IsNotFirstVisit = true;

      this.NavMenuItems = new List<NavMenuItem>
      {
        new NavMenuItem { Icon = Symbol.Home, Title = "Home", TargetViewModel = typeof(EventListViewModel) },
        new NavMenuItem { Icon = Symbol.Calendar, Title = "Events", TargetViewModel = typeof(EventListViewModel) }
      };
      this._selectedNavMenuItem = this.NavMenuItems.First();
      // Register a handler for BackRequested events and set the
      // visibility of the Back button
      SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
    }

    private void ShellViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      switch(e.PropertyName)
      {
        case nameof(this.SelectedNavMenuItem):
          this._navigationService.NavigateToViewModel(this.SelectedNavMenuItem.TargetViewModel);
          break;
      }
    }

    private void _navigationService_Navigated(object sender, NavigationEventArgs e)
    {
      SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            ((Frame)sender).CanGoBack ?
            AppViewBackButtonVisibility.Visible :
            AppViewBackButtonVisibility.Collapsed;

      this.IsNotFirstVisit = e.Content.GetType().Name != "VehicleAddView";
      this.CollapsedPanelLength = this.IsNotFirstVisit ? 50 : 0;
    }

    protected override void OnActivate()
    {
      _eventAggregator.Subscribe(this);
    }

    protected override void OnDeactivate(bool close)
    {
      _eventAggregator.Unsubscribe(this);
    }

    public void SetupNavigationService(Frame frame)
    {
      this._navigationService = _container.RegisterNavigationService(frame);
      this._navigationService.Navigated += _navigationService_Navigated;

      this.NavigateTo();
    }

    public void NavigateTo()
    {
      //if (_resume)
      //  _navigationService.ResumeState();
      var firstView = this.IsNotFirstVisit ? this.SelectedNavMenuItem.TargetViewModel : typeof(VehicleAddViewModel);
      this._navigationService.NavigateToViewModel(firstView);
    }

    
    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
      if (this._navigationService.CanGoBack && !e.Handled)
      {
        e.Handled = true;
        this._navigationService.GoBack();
      }
    }
  }
}
