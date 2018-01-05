using iVM.Vehicle.Model;
using System.Collections.Generic;

namespace iVM.Core.Entity.Services
{
  public interface IVehicleBrandRepository : IRepository<VehicleBrandModel>
  {
    IEnumerable<VehicleBrandModel> GetBrandsByType(int id);
  }
}
