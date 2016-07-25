using Caliburn.Micro;
using iVM.Events;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace iVM.UWP.App.ViewModels
{
  public class ShellViewModel : Screen, IHandle<ViewActionButtonsEvent>
  {
    private readonly WinRTContainer _container;
    private readonly IEventAggregator _eventAggregator;
    protected INavigationService _navigationService;

    private List<ActionButton> _actionButtons;

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
      get
      {
        return this._isNotFirstVisit;
      }
      set
      {
        this._isNotFirstVisit = value;
        this.NotifyOfPropertyChange(() => this.IsNotFirstVisit);
      }
    }
    public List<ActionButton> ActionButtons
    {
      get
      {
        return this._actionButtons;
      }
      set
      {
        this._actionButtons = value;
        this.NotifyOfPropertyChange(() => this.ActionButtons);
      }
    }


    public ShellViewModel(WinRTContainer container, IEventAggregator eventAggregator)
    {
      this._container = container;
      this._eventAggregator = eventAggregator;
      this.CollapsedPanelLength = 0;
      this._actionButtons = new List<ActionButton>();
      this.IsNotFirstVisit = false;

      // Register a handler for BackRequested events and set the
      // visibility of the Back button
      SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
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
      var firstView = this.IsNotFirstVisit ? typeof(EventListViewModel) : typeof(VehicleAddViewModel);
      this._navigationService.NavigateToViewModel(firstView);
    }

    public void Handle(ViewActionButtonsEvent message)
    {
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
