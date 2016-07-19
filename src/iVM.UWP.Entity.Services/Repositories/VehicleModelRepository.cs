using iVM.Core.Entity;
using iVM.Core.Repositories;
using iVM.Vehicle.Data.EF;
using iVM.Vehicle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace iVM.UWP.Entity.Services
{
  public class VehicleModelRepository : IVehicleModelRepository
  {
    private VehicleContext _ctxVehicle;
    public VehicleModelRepository(VehicleContext vehicleContext)
    {
      this._ctxVehicle = vehicleContext;
    }

    public void Add(VehicleModelEntity entity)
    {
      var vb = new VehicleBrandModel
      {
        Id = entity.ID,
        Title = entity.Name
      };
      this._ctxVehicle.VehicleBrands.Add(vb);
      this._ctxVehicle.SaveChanges();
    }
    public void Remove(int Id)
    {
      throw new NotImplementedException();
    }
    public IEnumerable<VehicleModelEntity> GetAll()
    {
      return this._ctxVehicle.VehicleBrands.Select(vb => new VehicleModelEntity() { ID = vb.Id, Name = vb.Title });
    }

    public VehicleModelEntity Get(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<VehicleModelEntity> Find(Expression<Func<VehicleModelEntity, bool>> predicate)
    {
      //return this._ctxVehicle.VehicleBrands.Select(v => v.ToEntity()).Where(predicate);
      throw new NotImplementedException();
    }

    public IEnumerable<VehicleModelEntity> GetModelsByBrandAndType(int typeId, int brandId)
    {
      return this._ctxVehicle.VehicleModels
        .Where(vm => (int)vm.Type == typeId && vm.BrandId == brandId)
        .Select(vm => new VehicleModelEntity
        {
          BrandId = vm.BrandId,
          vehicleTypeId = (int)vm.Type,
          ID = vm.Id,
          Name = vm.Name
        });
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        disposedValue = true;
      }
    }

    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    // ~VehicleRepository() {
    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //   Dispose(false);
    // }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      // GC.SuppressFinalize(this);
    }
    #endregion
  }
}
