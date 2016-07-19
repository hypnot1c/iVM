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
  public class VehicleTypeRepository : IVehicleTypeRepository
  {
    private VehicleContext _ctxVehicle;
    public VehicleTypeRepository(VehicleContext vehicleContext)
    {
      this._ctxVehicle = vehicleContext;
    }

    public void Add(VehicleTypeEntity entity)
    {
      throw new NotImplementedException();
    }

    public VehicleTypeEntity Get(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<VehicleTypeEntity> GetAll()
    {
      return Enum.GetNames(typeof(VehicleType)).Select(vb => new VehicleTypeEntity() { ID = -1, Name = vb });
    }

    public void Remove(int Id)
    {
      throw new NotImplementedException();
    }
    public IEnumerable<VehicleTypeEntity> Find(Expression<Func<VehicleTypeEntity, bool>> predicate)
    {
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
