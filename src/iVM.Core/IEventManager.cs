using iVM.Model;
using System.Collections.Generic;

namespace iVM.Core
{
  public interface IEventManager
  {
    void EventOccuredAdd(EventOccured ivmEvent);
    IEnumerable<EventType> EventTypes { get; }
  }
}
