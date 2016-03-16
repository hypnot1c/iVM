using System.Linq;

namespace iVM.Model
{
  public class EventType: BaseModel
  {
    public string Name { get; set; }
    public byte[] Icon { get; set; }

    public IQueryable<EventOccured> EventsOccured { get; set; }
  }
}
