using iVM.Core.Entity;
using System.Collections.Generic;

namespace iVM.Core.Repositories
{
  public interface IVehicleModelRepository : IRepository<VehicleModelEntity>
  {
    IEnumerable<VehicleModelEntity> GetModelsByBrandAndType(int typeId, int brandId);
  }
}
