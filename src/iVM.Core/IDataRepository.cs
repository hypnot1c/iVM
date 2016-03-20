using iVM.Model;
using System.Linq;

namespace iVM.Core
{
  public interface IDataRepository
  {
    IQueryable<User> Users { get; }
    IQueryable<EventType> EventTypes { get; }
    IQueryable<FillUp> FillUps { get; }

    void AddObject<TEntity>(TEntity entity) where TEntity : class;
    void UpdateObject<TEntity>(TEntity entity) where TEntity : class;

    void Migrate();
  }
}
