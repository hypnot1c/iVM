using iVM.Core;
using iVM.Data.Model;
using System.Linq;

namespace iVM.Data.SQL.EF
{
  public partial class SQLdataRepository : IRepository
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
