using iVM.Core;
using iVM.Model;
using System.Linq;

namespace iVM.Data
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
