using Caliburn.Micro;
using iVM.Core.Entity.Services;
using iVM.UWP.App.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace iVM.UWP.App.ViewModels
{
    public class ShellViewModel : Screen, IHandle<ResumeStateMessage>, IHandle<SuspendStateMessage>
    {
        private readonly WinRTContainer _container;
        private readonly IEventAggregator _eventAggregator;
        private readonly UserSessionService userSessionService;
        protected INavigationService _navigationService;
        private bool _resume;

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

        public IEnumerable<NavMenuItem> NavMenuItems { get; set; }

        private bool _syncNavMenu;

        private NavMenuItem _selectedNavMenuItem;
        public NavMenuItem SelectedNavMenuItem
        {
            get { return this._selectedNavMenuItem; }
            set
            {
                this._selectedNavMenuItem = value;
                this.NotifyOfPropertyChange(() => this.SelectedNavMenuItem);
            }
        }

        public ShellViewModel(
          WinRTContainer container,
          IEventAggregator eventAggregator,
          UserSessionService userSessionService
          )
        {
            this.PropertyChanged += ShellViewModel_PropertyChanged;
            this._container = container;
            this._eventAggregator = eventAggregator;
            this.userSessionService = userSessionService;
            this.CollapsedPanelLength = 0;

            this.NavMenuItems = new List<NavMenuItem>
      {
        new NavMenuItem { Icon = Symbol.Home, Title = "Home", TargetViewModel = typeof(PivotViewModel) }
        //new NavMenuItem { Icon = Symbol.Home, Title = "Home", TargetViewModel = typeof(EventListViewModel) },
        //new NavMenuItem { Icon = Symbol.Calendar, Title = "Events", TargetViewModel = typeof(EventListViewModel) }
      };
            this._selectedNavMenuItem = this.NavMenuItems.First();
            // Register a handler for BackRequested events and set the
            // visibility of the Back button
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        private void ShellViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.SelectedNavMenuItem):
                    if (this._syncNavMenu)
                    {
                        this._syncNavMenu = false;
                        this._navigationService.NavigateToViewModel(this.SelectedNavMenuItem.TargetViewModel);
                    }
                    break;
            }
        }

        private void _navigationService_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                  ((Frame)sender).CanGoBack ?
                  AppViewBackButtonVisibility.Visible :
                  AppViewBackButtonVisibility.Collapsed;

            //this.CollapsedPanelLength = this.IsNotFirstVisit ? 50 : 0;
            if (e.Content.GetType().Name == "PivotView")
            {
                this._syncNavMenu = true;
                this.SelectedNavMenuItem = this.NavMenuItems.FirstOrDefault(i => i.TargetViewModel.Name == "PivotViewModel");
            }
            this.CollapsedPanelLength = 0;
        }

        protected override void OnActivate()
        {
            _eventAggregator.SubscribeOnPublishedThread(this);
        }

        protected override void OnDeactivate(bool close)
        {
            _eventAggregator.Unsubscribe(this);
        }

        public void SetupNavigationService(Frame frame)
        {
            if (_container.HasHandler(typeof(INavigationService), null))
            {
                _container.UnregisterHandler(typeof(INavigationService), null);
            }

            this._navigationService = _container.RegisterNavigationService(frame);

            this._navigationService.Navigated += _navigationService_Navigated;
            this._navigationService.NavigationFailed += _navigationService_NavigationFailed;

            this.NavigateTo();
        }

        private void _navigationService_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public void NavigateTo()
        {
            if (_resume)
            {
                _navigationService.ResumeState();
            }
            else
            {
                this._navigationService.NavigateToViewModel(this.SelectedNavMenuItem.TargetViewModel);
            }
        }


        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this._navigationService.CanGoBack && !e.Handled)
            {
                e.Handled = true;
                this._navigationService.GoBack();
            }
        }

        public Task HandleAsync(ResumeStateMessage message, CancellationToken cancellationToken)
        {
            _navigationService.SuspendState();
            return Task.CompletedTask;
        }

        public Task HandleAsync(SuspendStateMessage message, CancellationToken cancellationToken)
        {
            _resume = true;
            return Task.CompletedTask;
        }
    }
}
