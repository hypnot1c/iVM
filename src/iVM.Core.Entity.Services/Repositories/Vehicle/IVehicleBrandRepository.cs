using System.Collections.Generic;

namespace iVM.Core.Entity.Services
{
  public interface IVehicleBrandRepository : IRepository<VehicleBrandEntity>
  {
    IEnumerable<VehicleBrandEntity> GetBrandsByType(int id);
  }
}
