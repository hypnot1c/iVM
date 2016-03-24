using Android.Content;

namespace iVM.Android.App.SQLdataRepository
{
  public partial class SQLdataRepository
  {
    public MainContext db { get; set; }

    public SQLdataRepository(Context context)
    {
      this.db = new MainContext(context);
    }
  }
}
