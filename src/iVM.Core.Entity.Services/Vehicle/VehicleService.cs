using iVM.Core.Repositories;
using System.Collections.Generic;

namespace iVM.Core.Entity.Services
{
  public class VehicleService
  {
    private readonly IVehicleBrandRepository vehicleBrandRepository;
    private readonly IVehicleTypeRepository vehicleTypeRepository;
    private readonly IVehicleRepository vehicleRepository;
    private readonly IVehicleModelRepository vehicleModelRepository;

    public VehicleService(
      IVehicleModelRepository vehicleModelRepository,
      IVehicleTypeRepository vehicleTypeRepository,
      IVehicleBrandRepository vehicleBrandRepository,
      IVehicleRepository vehicleRepository
      )
    {
      this.vehicleModelRepository = vehicleModelRepository;
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

    public IEnumerable<VehicleModelEntity> GetModelsByBrandAndType(int typeId, int brandId)
    {
      return this.vehicleModelRepository.GetModelsByBrandAndType(typeId, brandId);
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
