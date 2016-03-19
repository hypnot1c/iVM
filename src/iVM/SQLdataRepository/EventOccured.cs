using iVM.Core;
using iVM.Model;

namespace iVM.Data
{
  public partial class SQLdataRepository : IDataRepository
  {
    public void EventOccuredAdd(EventOccured eventOccured)
    {
      this.db.EventsOccured.Add(eventOccured);
      this.db.SaveChanges();
    }
  }
}
