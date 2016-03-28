using iVM.Core;
using iVM.Data.SQL.EF.SQLdatabase;
using iVM.Model;
using Microsoft.Data.Entity;
using System.Linq;

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

    public void SaveChanges()
    {
      this.db.SaveChanges();
    }

    public void AddObject<TEntity>(TEntity entity) where TEntity : class
    {
      this.db.Add(entity);
    }

    public void UpdateObject<TEntity>(TEntity entity) where TEntity : class
    {
      this.db.Update(entity);
    }

    public void FillUpAdd(EventOccured _evOccured, FillUp _fillUp)
    {
      _evOccured.EventTypeID = this.db.EventTypes.Where(et => et.Name == "FillUp").Select(et => et.ID).FirstOrDefault();
      _evOccured.FillUps.Add(_fillUp);
      _fillUp.EventOccured = _evOccured;
      this.AddObject(_evOccured);
    }

  }
}
