using iVM.Model;
using System;
using System.Linq;

namespace iVM.Data
{
  public partial class SQLdataRepository : IDataRepository
  {
    public IQueryable<User> Users
    {
      get
      {
        throw new NotImplementedException();
      }
    }
  }
}
