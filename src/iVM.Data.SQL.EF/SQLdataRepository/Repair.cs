using iVM.Core;
using iVM.Data.Model;
using System;
using System.Linq;

namespace iVM.Data.SQL.EF
{
  public partial class SQLdataRepository : IDataRepository
  {
    public IQueryable<Repair> Repairs
    {
      get
      {
        throw new NotImplementedException();
      }
    }
  }
}
