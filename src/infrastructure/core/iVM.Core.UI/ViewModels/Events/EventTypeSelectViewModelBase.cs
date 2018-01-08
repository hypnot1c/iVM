using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Data.Master.Context;
using System;

namespace iVM.Core.UI.ViewModels
{
  public abstract class EventTypeSelectViewModelBase : BaseViewModel
  {
    public EventTypeSelectViewModelBase(
      IEventAggregator eventAggregator,
      MasterContext masterContext) : base(eventAggregator)
    {
    }

    public Type EventTypes { get { return typeof(EventType); } }

    private string _selectedEventType;
    public string SelectedEventType
    {
      get { return this._selectedEventType; }
      set
      {
        this._selectedEventType = value;
        this.NotifyOfPropertyChange(() => this.SelectedEventType);
      }
    }

  }
}
