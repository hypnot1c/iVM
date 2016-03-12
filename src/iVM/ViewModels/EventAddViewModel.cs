using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.ViewModels
{
  public class EventAddViewModel : Screen
  {
    private readonly WinRTContainer _container;
    private readonly IEventAggregator _eventAggregator;
    protected INavigationService _navigationService;

    public EventAddViewModel(WinRTContainer container, IEventAggregator eventAggregator, INavigationService navigationService)
    {
      _container = container;
      _eventAggregator = eventAggregator;
      this._navigationService = navigationService;
    }

    protected override void OnActivate()
    {
      _eventAggregator.Subscribe(this);
    }

    protected override void OnDeactivate(bool close)
    {
      _eventAggregator.Unsubscribe(this);
    }
  }
}
