using Caliburn.Micro;
using iVM.Events;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace iVM.UWP.App.ViewModels
{
  public class ShellViewModel : Screen, IHandle<ViewActionButtonsEvent>
  {
    private readonly WinRTContainer _container;
    private readonly IEventAggregator _eventAggregator;
    protected INavigationService _navigationService;

    private List<ActionButton> _actionButtons;

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
      _container = container;
      _eventAggregator = eventAggregator;
      this._actionButtons = new List<ActionButton>();
      this.IsNotFirstVisit = false;
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
      _navigationService = _container.RegisterNavigationService(frame);
      if (!this.IsNotFirstVisit)
      {
        _navigationService.For<VehicleAddViewModel>().Navigate();
      }
      else
      {
        //_navigationService.For<>().Navigate();
      }
      //if (_resume)
      //  _navigationService.ResumeState();
    }

    public void NavigateTo()
    {
      //_navigationService.For<EventListViewModel>().Navigate();
    }

    public void Handle(ViewActionButtonsEvent message)
    {
      this.ActionButtons = message.ActionButtons;
    }

    private void onActionButton_Click(ActionButton source)
    {
      source.OnClick();
    }
  }
}
