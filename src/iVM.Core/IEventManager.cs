using iVM.Data.Model;
using System.Collections.Generic;

namespace iVM.Core
{
  public interface IEventManager
  {
    IEnumerable<EventOccured> EventsOccured { get; set; }
    IEnumerable<EventType> EventTypes { get; }

    void FillUpAdd(EventOccured _evOccured, FillUp _fillUp);
    void RepairAdd(EventOccured _evOccured, Repair _repair);
  }
}
