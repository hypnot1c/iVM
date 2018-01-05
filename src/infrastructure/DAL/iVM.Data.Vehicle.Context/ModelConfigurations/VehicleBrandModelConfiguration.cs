using iVM.Data.Vehicle.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class VehicleBrandModelConfiguration : IEntityTypeConfiguration<VehicleBrandModel>
  {
    public void Configure(EntityTypeBuilder<VehicleBrandModel> builder)
    {
      builder.HasKey(p => p.Id);
      builder.HasMany(t => t.VehicleTypes);
    }
  }
}
