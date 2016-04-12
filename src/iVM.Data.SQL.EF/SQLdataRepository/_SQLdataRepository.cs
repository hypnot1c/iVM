using iVM.Core;
using iVM.Data.Model;
using iVM.Data.SQL.EF.SQLdatabase;
using Microsoft.Data.Entity;
using System.Linq;

namespace iVM.Data.SQL.EF
{
  public partial class SQLdataRepository : IDataRepository
  {
    public MainContext db { get; set; }
    public VehicleContext vehicleDB { get; set; }

    public SQLdataRepository()
    {
      this.db = new MainContext();
      this.vehicleDB = new VehicleContext();
    }

    public void Migrate()
    {
      this.db.Database.Migrate();
      this.vehicleDB.Database.Migrate();
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

    public void RepairAdd(EventOccured _evOccured, Repair _repair)
    {
      _evOccured.EventTypeID = this.db.EventTypes.Where(et => et.Name == "Repair").Select(et => et.ID).FirstOrDefault();
      _evOccured.Repairs.Add(_repair);
      _repair.EventOccured = _evOccured;
      this.AddObject(_evOccured);
    }
  }
}
