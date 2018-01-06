using System.Collections.Generic;

namespace iVM.Data.Master.Model
{
  public class EventTypeModel : BaseModel
  {
    public string Name { get; set; }
    public byte[] Icon { get; set; }

    public ICollection<EventOccuredModel> EventsOccured { get; set; }
  }
}
