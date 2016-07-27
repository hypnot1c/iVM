using iVM.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace iVM.Core.Entity.Services
{
  public class VehicleService
  {
    private readonly IVehicleUnitOfWork _vehicleUoW;
    private readonly IMainUnitOfWork _mainUoW;

    public VehicleService(
      IVehicleUnitOfWork vehicleUoW,
      IMainUnitOfWork mainUoW
      )
    {
      this._vehicleUoW = vehicleUoW;
      this._mainUoW = mainUoW;
    }

    internal VehicleEntity GetVehicle(int Id)
    {
      var vehicle = this._mainUoW.Vehicles.Get(Id);
      var type = this._vehicleUoW.VehicleTypes.Get(vehicle.Type_vehicleTypeId);
      return VehicleEntity.CreateVehicle(new VehicleTypeEntity { Id = type.Id, Name = type.Name });
    }

    public IEnumerable<VehicleBrandEntity> GetAllBrands()
    {
      return this._vehicleUoW.VehcileBrands.GetAll()
        .Select(m => new VehicleBrandEntity { Id = m.Id, Name = m.Title });
    }
    public IEnumerable<VehicleTypeEntity> GetAllTypes()
    {
      return this._vehicleUoW.VehicleTypes.GetAll()
        .Select(m => new VehicleTypeEntity { Id = m.Id, Name = m.Name });
    }

    public IEnumerable<VehicleModelEntity> GetModelsByBrandAndType(int typeId, int brandId)
    {
      return this._vehicleUoW.VehicleModels.GetModelsByBrandAndType(typeId, brandId)
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
      return this._vehicleUoW.VehcileBrands.GetBrandsByType(Id)
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
      this._mainUoW.Vehicles.Add(vm);
    }
  }
}
