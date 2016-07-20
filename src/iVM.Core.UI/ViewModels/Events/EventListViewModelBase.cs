using Caliburn.Micro;

namespace iVM.Core.UI.ViewModels
{
  public class EventListViewModelBase: BaseViewModel
  {
    public EventListViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }
  }
}
