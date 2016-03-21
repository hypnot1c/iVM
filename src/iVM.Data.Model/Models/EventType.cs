using System.Collections.Generic;

namespace iVM.Model
{
  public class EventType: BaseModel
  {
    public string Name { get; set; }
    public byte[] Icon { get; set; }

    public ICollection<EventOccured> EventsOccured { get; set; }
  }
}
