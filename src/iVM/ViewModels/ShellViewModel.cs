using Caliburn.Micro;
using iVM.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace iVM.ViewModels
{
  public class ShellViewModel : Screen, IHandle<ViewActionButtonsEvent>
  {
    private readonly WinRTContainer _container;
    private readonly IEventAggregator _eventAggregator;
    protected INavigationService _navigationService;

    private List<ActionButton> _actionButtons;
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

      //if (_resume)
      //  _navigationService.ResumeState();
    }

    public void NavigateTo()
    {
      _navigationService.For<EventsViewModel>().Navigate();
    }

    public void Handle(ViewActionButtonsEvent message)
    {
      this.ActionButtons = message.ActionButtons;
    }

    public void GenerateActionButtons()
    {

    }
  }
}
