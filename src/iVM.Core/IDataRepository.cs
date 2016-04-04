using iVM.Data.Model;
using System.Linq;

namespace iVM.Core
{
  public interface IDataRepository
  {
    IQueryable<User> Users { get; }
    IQueryable<EventType> EventTypes { get; }
    IQueryable<EventOccured> EventsOccured { get; }
    IQueryable<FillUp> FillUps { get; }
    IQueryable<Repair> Repairs { get; }

    void AddObject<TEntity>(TEntity entity) where TEntity : class;
    void UpdateObject<TEntity>(TEntity entity) where TEntity : class;

    void Migrate();
    void SaveChanges();
    void FillUpAdd(EventOccured _evOccured, FillUp _fillUp);
    void RepairAdd(EventOccured _evOccured, Repair _repair);
  }
}
