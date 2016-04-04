using Caliburn.Micro;
using iVM.Data.Model;

namespace iVM.Core.UI.ViewModels
{
  public abstract class EventTypeSelectViewModelBase : BaseViewModel
  {
    private IObservableCollection<EventType> _eventTypes;
    public IObservableCollection<EventType> EventTypes
    {
      get { return this._eventTypes; }
      set
      {
        this._eventTypes = value;
        this.NotifyOfPropertyChange(() => this.EventTypes);
      }
    }

    public EventTypeSelectViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }
  }
}
