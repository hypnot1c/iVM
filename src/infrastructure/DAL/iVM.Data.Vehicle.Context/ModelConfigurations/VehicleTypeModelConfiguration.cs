using iVM.Data.Vehicle.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class VehicleTypeModelConfiguration : IEntityTypeConfiguration<VehicleTypeModel>
  {
    public void Configure(EntityTypeBuilder<VehicleTypeModel> builder)
    {
      builder.HasKey(p => p.Id);
      builder.HasMany(b => b.VehicleBrands);
    }
  }
}
