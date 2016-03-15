using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iVM.Model;

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
