using Caliburn.Micro;
using iVM.Data;
using iVM.Events;
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
    private readonly IDataRepository _dbRepository;
    protected INavigationService _navigationService;

    public EventAddViewModel(WinRTContainer container, IEventAggregator eventAggregator, INavigationService navigationService, IDataRepository dbRepository)
    {
      _container = container;
      _eventAggregator = eventAggregator;
      this._navigationService = navigationService;
      this._dbRepository = dbRepository;
    }

    protected override void OnActivate()
    {
      _eventAggregator.Subscribe(this);
    }

    protected override void OnDeactivate(bool close)
    {
      _eventAggregator.Unsubscribe(this);
    }

    public List<string> lstType
    {
      get
      {
        return this._dbRepository.EventTypes.Select(et => et.Name).ToList();
      }
    }
  }
}