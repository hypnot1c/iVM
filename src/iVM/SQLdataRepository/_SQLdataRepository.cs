using iVM.Data.SQLdatabase;
using Microsoft.Data.Entity;

namespace iVM.Data
{
  public partial class SQLdataRepository : IDataRepository
  {
    public MainContext db { get; set; }

    public SQLdataRepository()
    {
      this.db = new MainContext();
    }

    public void Migrate()
    {
      this.db.Database.Migrate();
    }

  }
}
