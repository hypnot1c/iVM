using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace iVM.UWP.Entity.Services
{
  public class VehicleRepository : EFRepository<VehicleModel>, IVehicleRepository
  {
    public MainContext MainContext { get { return this.context as MainContext; } }
    public VehicleRepository(DbContext context) : base(context)
    {
    }

    public override VehicleModel Get(int Id)
    {
      return this.MainContext.Vehicles.SingleOrDefault(v => v.Id == Id);
    }
  }
}
