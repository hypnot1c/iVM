using System.Collections.Generic;

namespace iVM.Core.Entity.Services
{
  public class VehicleService
  {
    private readonly IRepository<VehicleBrandEntity> vehicleBrandRepository;
    private readonly IRepository<VehicleTypeEntity> vehicleTypeRepository;

    public VehicleService(
      IRepository<VehicleTypeEntity> vehicleTypeRepository,
      IRepository<VehicleBrandEntity> vehicleBrandRepository
      )
    {
      this.vehicleTypeRepository = vehicleTypeRepository;
      this.vehicleBrandRepository = vehicleBrandRepository;
    }
    public IEnumerable<VehicleBrandEntity> GetAllBrands()
    {
      return this.vehicleBrandRepository.GetAll();
    }
    public IEnumerable<VehicleTypeEntity> GetAllTypes()
    {
      return this.vehicleTypeRepository.GetAll();
    }
  }
}
