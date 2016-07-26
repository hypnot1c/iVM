using iVM.Vehicle.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class VehicleBrandModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<VehicleBrandModel> builder)
    {
      builder.HasKey(p => p.Id);
      builder.HasMany(t => t.VehicleTypes);
    }
  }
}
