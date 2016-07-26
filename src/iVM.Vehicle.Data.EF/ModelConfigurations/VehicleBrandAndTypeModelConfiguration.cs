using iVM.Vehicle.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class VehicleBrandAndTypeModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<VehicleBrandAndTypeModel> builder)
    {
      builder.HasKey(p => new { p.BrandId, p.TypeId });
      builder.HasOne(b => b.Brand);
      builder.HasOne(t => t.Type);
    }
  }
}
