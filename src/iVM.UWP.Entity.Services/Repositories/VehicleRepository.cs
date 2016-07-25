using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;

namespace iVM.UWP.Entity.Services
{
  public class VehicleRepository : EFRepository<VehicleModel>, IVehicleRepository
  {
    public MainContext MainContext { get { return this.context as MainContext; } }
    public VehicleRepository(MainContext mainContext) : base(mainContext)
    {
    }
  }
}
