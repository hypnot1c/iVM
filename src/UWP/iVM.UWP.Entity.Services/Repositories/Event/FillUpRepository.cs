using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;

namespace iVM.UWP.Entity.Services
{
  public class FillUpRepository : EFRepository<FillUpModel>, IFillUpRepository
  {
    public MainContext MainContext { get { return this.context as MainContext; } }

    public FillUpRepository(MainContext mainContext) : base(mainContext)
    {
    }
  }
}
