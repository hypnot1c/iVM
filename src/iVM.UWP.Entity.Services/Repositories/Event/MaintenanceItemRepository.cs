using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;

namespace iVM.UWP.Entity.Services
{
  public class MaintenanceItemRepository : EFRepository<MaintenanceItemModel>, IMaintenanceItemRepository
  {
    public MainContext MainContext { get { return this.context as MainContext; } }

    public MaintenanceItemRepository(MainContext mainContext) : base(mainContext)
    {
    }
  }
}
