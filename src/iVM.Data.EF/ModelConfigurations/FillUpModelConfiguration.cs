using iVM.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class FillUpModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<FillUpModel> builder)
    {
      builder.HasKey(p => p.Id);
    }
  }
}
