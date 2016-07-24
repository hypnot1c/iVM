using iVM.Core.Entity;
using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace iVM.UWP.Entity.Services
{
  public class VehicleRepository : IVehicleRepository
  {
    private MainContext _ctxMain;
    public VehicleRepository(MainContext mainContext)
    {
      this._ctxMain = mainContext;
    }

    public void Add(VehicleEntity entity)
    {
      var vehicle = new VehicleModel
      {
        Model_vehicleModelId = entity.Model.Id,
        Type_vehicleTypeId = entity.Type.Id
      };

      this._ctxMain.Vehicles.Add(vehicle);
    }
    public void Remove(int Id)
    {
      throw new NotImplementedException();
    }
    public IEnumerable<VehicleEntity> GetAll()
    {
      throw new NotImplementedException();
    }

    public VehicleEntity Get(int id)
    {
      var vm = this._ctxMain.Vehicles.SingleOrDefault(v => v.Id == id);

      return new CarEntity
      {
        Id = vm.Id
      };
    }

    public IEnumerable<VehicleEntity> Find(Expression<Func<VehicleEntity, bool>> predicate)
    {
      //return this._ctxVehicle.VehicleBrands.Select(v => v.ToEntity()).Where(predicate);
      throw new NotImplementedException();
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
