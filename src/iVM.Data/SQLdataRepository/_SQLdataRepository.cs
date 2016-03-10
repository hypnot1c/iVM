using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iVM.Data.SQLdatabase;

namespace iVM.Data
{
  public partial class SQLdataRepository : IDataRepository
  {
    public MainContext db { get; set; }

  }
}
