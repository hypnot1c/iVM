using iVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
