using iVM.Core;
using iVM.Model;
using System.Linq;

namespace iVM.Data.SQL.EF
{
  public partial class SQLdataRepository : IDataRepository
  {
    public IQueryable<EventOccured> EventsOccured
    {
      get
      {
        return this.db.EventsOccured;
      }
    }
  }
}
