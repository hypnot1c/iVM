using iVM.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class EventOccuredModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<EventOccuredModel> builder)
    {
      builder.HasKey(p => p.Id);
    }
  }
}
