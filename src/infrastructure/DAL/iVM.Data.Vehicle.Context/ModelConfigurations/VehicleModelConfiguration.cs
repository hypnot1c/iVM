using iVM.Data.Vehicle.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class VehicleModelConfiguration : IEntityTypeConfiguration<VehicleModel>
  {
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
      builder.HasKey(p => p.Id);
    }
  }
}
