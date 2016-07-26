using iVM.Core.Entity.Services;
using iVM.Vehicle.Data.EF;
using iVM.Vehicle.Model;
using System.Linq;

namespace iVM.UWP.Entity.Services
{
  public class VehicleTypeRepository : EFRepository<VehicleTypeModel>, IVehicleTypeRepository
  {
    public VehicleContext VehicleContext { get { return this.context as VehicleContext; } }
    public VehicleTypeRepository(VehicleContext vehicleContext) : base(vehicleContext)
    {
    }

    public override VehicleTypeModel Get(int Id)
    {
      return this.VehicleContext.VehicleTypes.SingleOrDefault(v => v.Id == Id);
    }
  }
}
