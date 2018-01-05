using iVM.Vehicle.Model;
using System.Collections.Generic;

namespace iVM.Core.Entity.Services
{
  public interface IVehicleModelRepository : IRepository<VehicleModel>
  {
    IEnumerable<VehicleModel> GetModelsByBrandAndType(int typeId, int brandId);
  }
}
