using iVM.Model;
using System.Linq;

namespace iVM.Core
{
  public interface IDataRepository
  {
    IQueryable<User> Users { get; }
    IQueryable<EventType> EventTypes { get; }

    void EventOccuredAdd(EventOccured eventOccured);

    void Migrate();
  }
}
