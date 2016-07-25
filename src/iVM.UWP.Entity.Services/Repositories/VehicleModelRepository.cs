using iVM.Core.Entity.Services;
using iVM.Vehicle.Data.EF;
using iVM.Vehicle.Model;
using System.Collections.Generic;
using System.Linq;

namespace iVM.UWP.Entity.Services
{
  public class VehicleModelRepository : EFRepository<VehicleModel>, IVehicleModelRepository
  {
    public VehicleContext VehicleContext { get { return this.context as VehicleContext; } }
    public VehicleModelRepository(VehicleContext vehicleContext) : base(vehicleContext)
    {
    }
    public IEnumerable<VehicleModel> GetModelsByBrandAndType(int typeId, int brandId)
    {
      return this.VehicleContext.VehicleModels
        .Where(vm => vm.Type_TypeId == typeId && vm.Brand_BrandId == brandId)
        .ToList()
        ;
    }
  }
}
