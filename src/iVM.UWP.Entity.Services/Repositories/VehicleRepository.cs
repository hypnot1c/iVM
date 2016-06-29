using iVM.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace iVM.UWP.Entity.Services
{
  public class VehicleRepository : EFRepository<VehicleEntity>
  {
    public VehicleRepository(DbContext dbContext) : base(dbContext)
    {

    }
  }
}
