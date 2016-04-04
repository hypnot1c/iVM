using Caliburn.Micro;
using iVM.Data.Model;

namespace iVM.Core.UI.ViewModels.Events
{
  public class EventListViewModelBase: BaseViewModel
  {
    private IObservableCollection<EventOccured> _events;
    public IObservableCollection<EventOccured> Events
    {
      get { return this._events; }
      set
      {
        this._events = value;
        this.NotifyOfPropertyChange(() => this.Events);
      }
    }

    public EventListViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }
  }
}
