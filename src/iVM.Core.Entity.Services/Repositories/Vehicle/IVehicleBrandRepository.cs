using iVM.Core.Entity;
using System.Collections.Generic;

namespace iVM.Core.Repositories
{
  public interface IVehicleBrandRepository : IRepository<VehicleBrandEntity>
  {
    IEnumerable<VehicleBrandEntity> GetBrandsByType(int id);
  }
}
