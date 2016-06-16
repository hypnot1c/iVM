using iVM.Core.Entity;
using System.Linq;

namespace iVM.Core
{
  public interface IDataRepository
  {
    IQueryable<UserEntity> Users { get; }
    IQueryable<EventType> EventTypes { get; }
    IQueryable<EventOccuredEntity> EventsOccured { get; }
    IQueryable<FillUpEntity> FillUps { get; }
    IQueryable<RepairEntity> Repairs { get; }

    void AddObject<TEntity>(TEntity entity) where TEntity : class;
    void UpdateObject<TEntity>(TEntity entity) where TEntity : class;

    void Migrate();
    void SaveChanges();
  }
}
