using iVM.Core;
using iVM.Model;
using System;
using System.Linq;

namespace iVM.Data
{
  public partial class SQLdataRepository : IDataRepository
  {
    public IQueryable<FillUp> FillUps
    {
      get
      {
        throw new NotImplementedException();
      }
    }
  }
}
