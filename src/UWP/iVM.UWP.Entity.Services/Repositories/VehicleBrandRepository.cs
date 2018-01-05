using iVM.Core.Entity.Services;
using iVM.Vehicle.Data.EF;
using iVM.Vehicle.Model;
using System.Collections.Generic;
using System.Linq;

namespace iVM.UWP.Entity.Services
{
  public class VehicleBrandRepository : EFRepository<VehicleBrandModel>, IVehicleBrandRepository
  {
    public VehicleContext VehicleContext { get { return this.context as VehicleContext; } }
    public VehicleBrandRepository(VehicleContext vehicleContext) : base(vehicleContext)
    {
    }
    public IEnumerable<VehicleBrandModel> GetBrandsByType(int id)
    {
      return this.VehicleContext.VehicleBrands
        .Where(b => b.VehicleTypes.Any(t => t.TypeId == id))
        .ToList()
        ;
    }
  }
}
