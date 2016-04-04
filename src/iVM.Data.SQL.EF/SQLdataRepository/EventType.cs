using iVM.Core;
using iVM.Data.Model;
using System.Linq;

namespace iVM.Data.SQL.EF
{
  public partial class SQLdataRepository : IDataRepository
  {
    public IQueryable<EventType> EventTypes
    {
      get
      {
        return this.db.EventTypes;
      }
    }
  }
}
