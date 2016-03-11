using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.ViewModels
{
  public class EventsViewModel: BaseViewModel
  {
    public EventsViewModel(WinRTContainer container, IEventAggregator eventAggregator) : base(container, eventAggregator)
    {
    }
  }
}
