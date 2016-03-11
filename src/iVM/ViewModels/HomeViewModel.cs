using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.ViewModels
{
  public class HomeViewModel : BaseViewModel
  {
    public HomeViewModel(WinRTContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
    {
    }

    public void NavigateTo()
    {
      this._navigationService.For<EventsViewModel>().Navigate();
    }
  }
}
