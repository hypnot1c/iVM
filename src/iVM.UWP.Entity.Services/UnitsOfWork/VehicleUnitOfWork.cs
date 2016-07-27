using iVM.Core.Entity.Services;
using iVM.Vehicle.Data.EF;
using System;

namespace iVM.UWP.Entity.Services
{
  public class VehicleUnitOfWork : IVehicleUnitOfWork
  {
    private readonly VehicleContext _context;

    public VehicleUnitOfWork(VehicleContext context)
    {
      this._context = context;
    }
    private IVehicleBrandRepository _vehicleBrands;
    public IVehicleBrandRepository VehcileBrands
    {
      get
      {
        if(this._vehicleBrands == null)
        {
          this._vehicleBrands = new VehicleBrandRepository(this._context);
        }
        return this._vehicleBrands;
      }
    }

    private IVehicleModelRepository _vehicleModels;
    public IVehicleModelRepository VehicleModels
    {
      get
      {
        if (this._vehicleModels == null)
        {
          this._vehicleModels = new VehicleModelRepository(this._context);
        }
        return this._vehicleModels;
      }
    }

    private IVehicleTypeRepository _vehicleTypes;
    public IVehicleTypeRepository VehicleTypes
    {
      get
      {
        if (this._vehicleTypes == null)
        {
          this._vehicleTypes = new VehicleTypeRepository(this._context);
        }
        return this._vehicleTypes;
      }
    }

    public void Commit()
    {
      this._context.SaveChanges();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public void Rollback()
    {
      throw new NotImplementedException();
    }

    public void Save()
    {
      this._context.SaveChanges();
    }
  }
}
