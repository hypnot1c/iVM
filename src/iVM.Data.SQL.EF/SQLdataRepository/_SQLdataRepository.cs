using iVM.Core;
using iVM.Data.SQL.EF.SQLdatabase;
using Microsoft.Data.Entity;

namespace iVM.Data.SQL.EF
{
  public partial class SQLdataRepository : IDataRepository
  {
    public MainContext db { get; set; }

    public SQLdataRepository()
    {
      this.db = new MainContext();
    }

    public void Migrate()
    {
      this.db.Database.Migrate();
    }

    public void AddObject<TEntity>(TEntity entity) where TEntity : class
    {
      this.db.Add(entity);
    }

    public void UpdateObject<TEntity>(TEntity entity) where TEntity : class
    {
      this.db.Update(entity);
    }

  }
}
