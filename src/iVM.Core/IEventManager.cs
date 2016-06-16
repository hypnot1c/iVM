using iVM.Core.Entity;
using System.Collections.Generic;

namespace iVM.Core
{
  public interface IEventManager
  {
    IEnumerable<EventOccuredEntity> EventsOccured { get; set; }
    IEnumerable<EventType> EventTypes { get; }

    void FillUpAdd(FillUpEntity _fillUp);
    void RepairAdd(RepairEntity _repair);
  }
}
