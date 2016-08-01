using System.Collections.Generic;

namespace iVM.Data.Model
{
  public class EventType: BaseModel
  {
    public string Name { get; set; }
    public byte[] Icon { get; set; }

    public ICollection<EventOccuredModel> EventsOccured { get; set; }
  }
}
