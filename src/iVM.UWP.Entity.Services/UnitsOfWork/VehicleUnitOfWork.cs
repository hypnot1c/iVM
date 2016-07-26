using iVM.Core.Entity.Services;
using iVM.Vehicle.Data.EF;
using System;

namespace iVM.UWP.Entity.Services
{
  public class VehicleUnitOfWork : IVehicleUnitOfWork
  {
    private readonly VehicleContext context;

    public VehicleUnitOfWork(VehicleContext context)
    {
      this.context = context;
    }
    public IVehicleBrandRepository VehcileBrands
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public IVehicleModelRepository VehicleModels
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public IVehicleTypeRepository VehicleTypes
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public void Commit()
    {
      this.context.SaveChanges();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public void Rollback()
    {
      throw new NotImplementedException();
    }
  }
}
