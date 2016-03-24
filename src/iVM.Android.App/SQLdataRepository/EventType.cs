using iVM.Model;
using System.Linq;

namespace iVM.Android.App.SQLdataRepository
{
  public partial class SQLdataRepository
  {
    public IQueryable<EventType> EventTypes
    {
      get
      {
        return this.db.con.Table<EventType>().AsQueryable();
      }
    }
  }
}
