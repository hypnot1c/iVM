using iVM.Vehicle.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class VehicleTypeModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<VehicleTypeModel> builder)
    {
      builder.HasKey(p => p.Id);
    }
  }
}
