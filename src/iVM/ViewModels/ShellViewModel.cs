using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace iVM.ViewModels
{
  public class ShellViewModel: Screen
  {
    private readonly WinRTContainer _container;
    private readonly IEventAggregator _eventAggregator;
    protected INavigationService _navigationService;

    public ShellViewModel(WinRTContainer container, IEventAggregator eventAggregator)
    {
      _container = container;
      _eventAggregator = eventAggregator;
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
  }
}
