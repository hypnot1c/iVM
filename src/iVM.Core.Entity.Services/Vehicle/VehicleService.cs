using iVM.Core.Repositories;
using System.Collections.Generic;

namespace iVM.Core.Entity.Services
{
  public class VehicleService
  {
    private readonly IVehicleBrandRepository vehicleBrandRepository;
    private readonly IVehicleTypeRepository vehicleTypeRepository;
    private readonly IVehicleRepository vehicleRepository;

    public VehicleService(
      IVehicleTypeRepository vehicleTypeRepository,
      IVehicleBrandRepository vehicleBrandRepository,
      IVehicleRepository vehicleRepository
      )
    {
      this.vehicleTypeRepository = vehicleTypeRepository;
      this.vehicleBrandRepository = vehicleBrandRepository;
      this.vehicleRepository = vehicleRepository;
    }
    public IEnumerable<VehicleBrandEntity> GetAllBrands()
    {
      return this.vehicleBrandRepository.GetAll();
    }
    public IEnumerable<VehicleTypeEntity> GetAllTypes()
    {
      return this.vehicleTypeRepository.GetAll();
    }

    public IEnumerable<VehicleBrandEntity> GetBrandsByType(int Id)
    {
      return this.vehicleBrandRepository.GetBrandsByType(Id);
    }

    public void AddVehicleToUser(VehicleEntity vehicle)
    {
      this.vehicleRepository.Add(vehicle);
    }
  }
}
