using iVM.Core.Entity.Services;
using iVM.Vehicle.Data.EF;
using iVM.Vehicle.Model;

namespace iVM.UWP.Entity.Services
{
  public class VehicleTypeRepository : EFRepository<VehicleTypeModel>, IVehicleTypeRepository
  {
    public VehicleContext VehicleContext { get { return this.context as VehicleContext; } }
    public VehicleTypeRepository(VehicleContext vehicleContext) : base(vehicleContext)
    {
    }
  }
}
