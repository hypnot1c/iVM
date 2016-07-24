using System.Collections.Generic;

namespace iVM.Core.Entity.Services
{
  public interface IVehicleModelRepository : IRepository<VehicleModelEntity>
  {
    IEnumerable<VehicleModelEntity> GetModelsByBrandAndType(int typeId, int brandId);
  }
}
