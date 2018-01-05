using iVM.Data.Master.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class FillUpModelConfiguration : IEntityTypeConfiguration<FillUpModel>
  {
    public void Configure(EntityTypeBuilder<FillUpModel> builder)
    {
      builder.HasKey(p => p.Id);
    }
  }
}
