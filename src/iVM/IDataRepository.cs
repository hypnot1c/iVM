using iVM.Model;
using System.Linq;

namespace iVM.Data
{
  public interface IDataRepository
  {
    IQueryable<User> Users { get; }
    IQueryable<EventType> EventTypes { get; }

    void Migrate();
  }
}
