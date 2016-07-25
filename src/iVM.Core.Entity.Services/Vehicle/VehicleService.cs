using iVM.Data.Model;
using System.Collections.Generic;
using System.Linq;

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

    internal VehicleEntity GetVehicle(int Id)
    {
      var vehicle = this.vehicleRepository.Get(Id);
      var type = this.vehicleTypeRepository.Get(vehicle.Type_vehicleTypeId);
      return VehicleEntity.CreateVehicle(new VehicleTypeEntity { Id = type.Id, Name = type.Name });
    }

    public IEnumerable<VehicleBrandEntity> GetAllBrands()
    {
      return this.vehicleBrandRepository.GetAll()
        .Select(m => new VehicleBrandEntity { Id = m.Id, Name = m.Title });
    }
    public IEnumerable<VehicleTypeEntity> GetAllTypes()
    {
      return this.vehicleTypeRepository.GetAll()
        .Select(m => new VehicleTypeEntity { Id = m.Id, Name = m.Name });
    }

    public IEnumerable<VehicleModelEntity> GetModelsByBrandAndType(int typeId, int brandId)
    {
      return this.vehicleModelRepository.GetModelsByBrandAndType(typeId, brandId)
        .Select(m => new VehicleModelEntity
        {
          Id = m.Id,
          Name = m.Name,
          BrandId = m.Brand_BrandId,
          vehicleTypeId = m.Type_TypeId
        });
    }

    public IEnumerable<VehicleBrandEntity> GetBrandsByType(int Id)
    {
      return this.vehicleBrandRepository.GetBrandsByType(Id)
        .Select(b => new VehicleBrandEntity { Id = b.Id, Name = b.Title });
    }

    public void AddVehicleToUser(VehicleEntity vehicle)
    {
      var vm = new VehicleModel
      {
        Id = vehicle.Id,
        Model_vehicleModelId = vehicle.Model.Id,
        Type_vehicleTypeId = vehicle.Type.Id
      };
      this.vehicleRepository.Add(vm);
    }
  }
}
