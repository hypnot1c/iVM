using iVM.Core;
using iVM.Data.Model;
using System;
using System.Linq;

namespace iVM.Data.SQL.EF
{
  public partial class SQLdataRepository : IRepository
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
