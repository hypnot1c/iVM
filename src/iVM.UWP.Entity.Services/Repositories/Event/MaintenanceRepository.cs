using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;

namespace iVM.UWP.Entity.Services
{
  public class MaintenanceRepository : EFRepository<MaintenanceModel>, IMaintenanceRepository
  {
    public MainContext MainContext { get { return this.context as MainContext; } }

    public MaintenanceRepository(MainContext mainContext) : base(mainContext)
    {
    }
  }
}
